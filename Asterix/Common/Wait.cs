using System;
using System.Threading;
using NLog;

namespace Asterix.Framework.Common
{
    public static class Wait
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void Until(Func<bool> condition, int timeOutInSecond = 60, int intervalInSecond = 1)
        {
            logger.Info("Until was called");
            for (var i = 0; i < timeOutInSecond; i++)
            {
                try
                { 
                    if (condition())
                    {
                        return;
                    }
                }
                catch { }

                Thread.Sleep(TimeSpan.FromSeconds(intervalInSecond));
            }

            logger.Error("Timeout reached without the condition begins true");
            throw new TimeoutException("Timeout reached without the condition begins true");
        }
    }

    //Legyen egy SafeWait osztály is, az nem dob exception
}
