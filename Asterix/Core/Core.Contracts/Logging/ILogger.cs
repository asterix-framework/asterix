namespace Asterix.Core.Contracts.Logging
{
    public interface ILogger
    {
        void Debug(string message, params object[] arg);

        void Info(string message, params object[] arg);

        void Warning(string message, params object[] arg);

        void Error(string message, params object[] arg);
    }
}
