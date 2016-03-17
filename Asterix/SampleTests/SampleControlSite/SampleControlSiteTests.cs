using Asterix.Framework.WebUi.Browser;
using NUnit.Framework;

namespace SampleTests.SampleControlSite
{
    [TestFixture]
    public class SampleControlSiteTests
    {
        [Test]
        public void SelectDropdownItems()
        {
            using (var webBrowser = BrowserFactory.Create())
            {
                Pages.SampleControlSite site = new Pages.SampleControlSite(webBrowser);

                site.MainPage.Navigate();
                var dropDownPage = site.MainPage.ClickOnDropDown();
                
                dropDownPage.DropDownElement.SelectByIndex(1);
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Element.Text, Is.EqualTo("Option 1"));
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Value, Is.EqualTo("1"));

                dropDownPage.DropDownElement.SelectByValue("2");
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Element.Text, Is.EqualTo("Option 2"));
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Value, Is.EqualTo("2"));

                dropDownPage.DropDownElement.SelectByText("Option 1");
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Element.Text, Is.EqualTo("Option 1"));
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Value, Is.EqualTo("1"));
            }
        }

        [Test]
        public void SelectDropdownItemsWithJavascript()
        {
            using (var webBrowser = BrowserFactory.Create())
            {
                Pages.SampleControlSite site = new Pages.SampleControlSite(webBrowser);

                site.MainPage.Navigate();
                var dropDownPage = site.MainPage.ClickOnDropDown();

                dropDownPage.DropDownElement.Javascript.SelectByIndex(1);
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Element.Text, Is.EqualTo("Option 1"));
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Value, Is.EqualTo("1"));

                dropDownPage.DropDownElement.Javascript.SelectByValue("2");
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Element.Text, Is.EqualTo("Option 2"));
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Value, Is.EqualTo("2"));

                dropDownPage.DropDownElement.Javascript.SelectByText("Option 1");
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Element.Text, Is.EqualTo("Option 1"));
                Assert.That(dropDownPage.DropDownElement.SelectedOption.Value, Is.EqualTo("1"));
            }
        }
    }
}
