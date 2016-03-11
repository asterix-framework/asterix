using Asterix.Framework.WebUi.Browser;
using NUnit.Framework;
using SampleTests.google.Pages;

namespace SampleTests.google
{
    [TestFixture]
    public class GoogleTests
    {
        [Test]
        public void SearchFor1Plus1()
        {
            using (var webBrowser = BrowserFactory.Create())
            {
                var google = new Google(webBrowser);

                google.MainPage.Navigate();

                Assert.That(google.MainPage.Search.Element.Displayed, Is.True);

                google.MainPage.Search.Type("1+1");

                google.MainPage.SearchButton.Click();
                google.MainPage.SearchButton.Actions.Click();
                google.MainPage.SearchButton.Javascript.Click();

                Assert.That(google.MainPage.CalculatorResult.Text, Is.EqualTo("2"));
            }
        }
    }
}
