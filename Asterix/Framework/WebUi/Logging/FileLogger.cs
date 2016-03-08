using System;
using System.IO;

namespace Asterix.Framework.WebUi.Logging
{
    public class FileLogger : LoggerBase
    {
        public FileLogger(IDatetTimeProvider datetTimeProvider) : base(datetTimeProvider)
        {
        }

        protected override void Publish(string message)
        {
            string directoryName = Path.Combine(Environment.CurrentDirectory, "Log");
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            string fileName = DatetTimeProvider.Now().ToString("yyyy-MM-dd") + ".txt";

            using (StreamWriter streamWriter = File.AppendText(Path.Combine(directoryName, fileName)))
            {
                streamWriter.Write(message);
            }
        }

    }
}
