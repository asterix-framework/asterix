using System;

namespace Asterix.Framework.WebUi.Logging
{
    public class ConsoleLogger : LoggerBase
    {
        public ConsoleLogger(IDatetTimeProvider datetTimeProvider) : base(datetTimeProvider)
        {
        }

        protected override void Publish(string message)
        {
            Console.WriteLine(message);
        }
    }
}
