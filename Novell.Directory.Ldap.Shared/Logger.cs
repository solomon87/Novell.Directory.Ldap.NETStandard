using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Novell.Directory.Ldap
{
    public static class Logger
    {
        private static ILoggerFactory _loggerFactory;
        private static ILogger _log;

        static Logger()
        {
            Factory = new LoggerFactory().AddDebug();
        }

        [CLSCompliant(false)]
        public static ILoggerFactory Factory
        {
            get { return _loggerFactory; }
            set
            {
                _loggerFactory = value;
                Init();
            }
        }

        [CLSCompliant(false)]
        public static ILogger Log => _log;

        [CLSCompliant(false)]
        public static void LogWarning(this ILogger logger, string message, Exception ex)
        {
            logger.LogWarning(message + " - {0}", ex.ToString());
        }

        private static void Init()
        {
            _log = _loggerFactory.CreateLogger("Ldap");
        }
    }
}