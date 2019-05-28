using System;
using System.Diagnostics;
using log4net;
using Microsoft.AspNet.WebHooks.Diagnostics;

namespace GenericReceivers.Dependencies
{
    public class Log4NetLogger : ILogger
    {
        private static readonly ILog Logger = LogManager.GetLogger("WebHooks");

        public void Log(TraceLevel level, string message, Exception ex)
        {
            switch (level)
            {
                case TraceLevel.Error:
                    Logger.Error(message, ex);
                    break;

                case TraceLevel.Warning:
                    Logger.Warn(message, ex);
                    break;

                case TraceLevel.Info:
                    Logger.Info(message, ex);
                    break;
            }
        }
    }
}
