using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Crazylight.Common.Helpers
{
	public class NLogHelper
	{
		static NLog.ILogger logger;
		static NLogHelper()
		{
			logger = NLog.LogManager.GetLogger("Diary");

		}
		public static void LogInfo(string msg)
		{
			logger.Info(msg);
		}
		public static void LogError(string msg)
		{
			logger.Error(msg);
		}
		public static void LogData(string msg)
		{
			logger.Debug(msg);
		}
	}
}
