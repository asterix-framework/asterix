using System;
using Asterix.Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asterix.Framework.CommonTests
{
    [TestClass]
    public class WaitTests
    {
        [TestMethod]
        public void VerifyWaitIsWorkingIfTheConditionComesTrueBeforeTimeout()
        {
            DateTime endTime = DateTime.Now.AddSeconds(3);

            var condition = GetCondition(endTime);

            Wait.Until(condition, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeoutException))]
        public void VerifyWaitTimeoutExceptionIsThrownIfTimeoutIsReached()
        {
            DateTime endTime = DateTime.Now.AddSeconds(10);

            var condition = GetCondition(endTime);

            Wait.Until(condition, 2);
        }

        [TestMethod]
        public void VerifySafeWaitNotThrewTimeOutExceptionIfTimeoutIsReached()
        {
            DateTime endTime = DateTime.Now.AddSeconds(10);

            var condition = GetCondition(endTime);

            SafeWait.Until(condition, 2);
        }


        private static Func<bool> GetCondition(DateTime endTime)
        {
            return () =>
            {
                int compareResult = DateTime.Compare(DateTime.Now, endTime);
                if (compareResult >= 0)
                {
                    return true;
                }

                return false;
            };
        }
    }
}
