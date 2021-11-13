using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using log4net.Util;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ExportExtender.App
{
	public static class Logging
	{
		public static MemoryAppender MemoryAppender { get; private set; }
		public static PatternLayout MemoryAppenderPatternLayout { get; private set; }

		public static bool Init()
		{
			// configure log4net
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

			// will need these for showing logs in the program window
			MemoryAppender = new MemoryAppender();
			MemoryAppenderPatternLayout = new PatternLayout("%d %-5p %m%n");
			((Hierarchy)logRepository).Root.AddAppender(MemoryAppender);

			// return whether succeeded
			return LogManager.GetRepository().Configured;
		}

		public static string FirstError()
		{
			foreach (LogLog message in
					LogManager.GetRepository().ConfigurationMessages.Cast<LogLog>())
			{
				// guessing just the first one is enough
				return message.Message;
			}
			return "";
		}
	}
}
