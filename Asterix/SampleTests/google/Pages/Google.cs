using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asterix.Framework.WebUi.Browser;

namespace SampleTests.google.Pages
{
    public class Google
    {
        private readonly Browser _browser;

        public const string ServerAddress = "https://google.com";

        public Google(Browser browser)
        {
            _browser = browser;
        }

        public MainPage MainPage { get { return new MainPage(_browser); } }
    }
}
