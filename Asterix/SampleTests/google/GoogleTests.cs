using Asterix.Framework.WebUi.Browser;
using NUnit.Framework;
using SampleTests.google.Pages;

namespace SampleTests.google
{
    [TestFixture]
    public class GoogleTests
    {
        [Test]
        public void SearchForSomething()
        {
            using (var browser = BrowserFactory.Create(BrowserType.Firefox))
            {
                var google = new Google(browser);

                google.MainPage.Navigate(Google.ServerAddress);

                google.MainPage.Search.Type("hello");
                google.MainPage.SearchButton.Click();
            }
        }
    }
}
