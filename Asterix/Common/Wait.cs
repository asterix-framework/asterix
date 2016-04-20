using System;
using System.Threading;

namespace Asterix.Framework.Common
{
    public static class Wait
    {
        public static void WaitUntilSuceed(Func<bool> condition, int timeOutInSecond = 60, int intervalInSecond = 1)
        {
            for (var i = 0; i < timeOutInSecond; i++)
            {
                if (condition())
                {
                    return;
                } 
        
                Thread.Sleep(TimeSpan.FromSeconds(intervalInSecond));
            }

            throw new TimeoutException("Timeout reached without the condition begins true");
        }

    }
}
