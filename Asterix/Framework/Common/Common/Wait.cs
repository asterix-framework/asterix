using System;
using System.Threading;
using NLog;

namespace Asterix.Framework.Common
{
    public static class Wait
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static void Until(Func<bool> condition, int timeOutInSecond = 60, int intervalInSecond = 1)
        {
            Logger.Info("Until was called");

            if (WaitHelper.WaitForCoditionComesTrueOrTimeOutIsReached(condition, timeOutInSecond, intervalInSecond))
            {
                return;
            }

            Logger.Error("Timeout reached without the condition had come true");
            throw new TimeoutException("Timeout reached without the condition had come true");
        }
    }
}
