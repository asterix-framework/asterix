using System;
using NLog;

namespace Asterix.Framework.Common
{
    public static class SafeWait
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static void Until(Func<bool> condition, int timeOutInSecond = 60, int intervalInSecond = 1)
        {
            Logger.Info("Until was called");
            WaitHelper.WaitForCoditionComesTrueOrTimeOutIsReached(condition, timeOutInSecond, intervalInSecond);
        }
    }
}

