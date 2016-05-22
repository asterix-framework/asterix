using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asterix.Framework.Common
{
    internal static class WaitHelper
    {
        internal static bool WaitForCoditionComesTrueOrTimeOutIsReached(Func<bool> condition, int timeOutInSecond, int intervalInSecond)
        {
            for (var i = 0; i < timeOutInSecond; i++)
            {
                try
                {
                    if (condition())
                    {
                        return true;
                    }
                }
                catch { }

                Thread.Sleep(TimeSpan.FromSeconds(intervalInSecond));
            }

            return false;
        }
    }
}
