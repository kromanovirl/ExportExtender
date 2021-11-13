using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Security.AccessControl;
using System.Security.Principal;
using System;

namespace ExportExtender.App
{
	// adapted from:
	// https://stackoverflow.com/a/229567

	public class SingleGlobalInstance : IDisposable
	{
		private bool _hasHandle = false;
		private Mutex _mutex;

		private void InitMutex()
		{
			string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value;
			string mutexId = string.Format("Global\\{{{0}}}", appGuid);
			_mutex = new Mutex(false, mutexId);

			var allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MutexRights.FullControl, AccessControlType.Allow);
			var securitySettings = new MutexSecurity();
			securitySettings.AddAccessRule(allowEveryoneRule);
			_mutex.SetAccessControl(securitySettings);
		}

		private SingleGlobalInstance(int timeOut)
		{
			InitMutex();
			try
			{
				if (timeOut < 0)
					_hasHandle = _mutex.WaitOne(Timeout.Infinite, false);
				else
					_hasHandle = _mutex.WaitOne(timeOut, false);

				if (_hasHandle == false)
					throw new TimeoutException("Timeout waiting for single instance mutex");
			}
			catch (AbandonedMutexException)
			{
				_hasHandle = true;
			}
		}

		public void Dispose()
		{
			if (_mutex != null)
			{
				if (_hasHandle)
					_mutex.ReleaseMutex();
				_mutex.Close();
			}
		}

		public static SingleGlobalInstance Acquire()
		{
			try
			{
				return new SingleGlobalInstance(0);
			}
			catch (TimeoutException)
			{
				return null; // could not acquire
			}
		}
	}
}
