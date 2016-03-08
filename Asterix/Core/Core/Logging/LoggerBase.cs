using System.Globalization;
using Asterix.Core.Contracts;
using Asterix.Core.Contracts.Logging;

namespace Asterix.Core.Logging
{
    public abstract class LoggerBase : ILogger
    {
        protected readonly IDatetTimeProvider DatetTimeProvider;

        protected LoggerBase(IDatetTimeProvider datetTimeProvider)
        {
            DatetTimeProvider = datetTimeProvider;
        }

        public void Debug(string message, params object[] arg)
        {
            string logMessage = "[Debug]" + GetTimeStamp() + string.Format(message, arg);
            Publish(logMessage);
        }

        public void Info(string message, params object[] arg)
        {
            string logMessage = "[Info]" + GetTimeStamp() + string.Format(message, arg);
            Publish(logMessage);
        }

        public void Warning(string message, params object[] arg)
        {
            string logMessage = "[Warning]" + GetTimeStamp() + string.Format(message, arg);
            Publish(logMessage);
        }

        public void Error(string message, params object[] arg)
        {
            string logMessage = "[Error]" + GetTimeStamp() + string.Format(message, arg);
            Publish(logMessage);
        }

        private string GetTimeStamp()
        {
            return " " + DatetTimeProvider.Now().ToString("dd/MM/yyyy HH:mm:ss.fff",
                                CultureInfo.InvariantCulture) + " ";
        }

        protected abstract void Publish(string message);
    }
}
