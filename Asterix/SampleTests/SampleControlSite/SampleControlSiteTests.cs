using System;
using System.Threading;
using Asterix.Framework.WebUi;
using Asterix.Framework.WebUi.Browser;
using Asterix.Framework.WebUi.Elements.SpecificElements;
using NUnit.Framework;
using TestContext.Configuration;

namespace SampleTests.SampleControlSite.Pages
{
    [TestFixture]
    public class SampleControlSiteTests
    {
        [Test]
        public void CheckBoxTest()
        {
            var webBrowser = BrowserFactory.Create();
            var site = new Pages.SampleControlSite(webBrowser);
            site.MainPage.Navigate();
            var checkBoxPage = site.MainPage.ClickOnCheckBox();
            checkBoxPage.FirstCheckBoxElement.Check();
            Thread.Sleep(3000);
            Assert.That(checkBoxPage.FirstCheckBoxElement.Checked, Is.True);
            checkBoxPage.FirstCheckBoxElement.UnCheck();
            Assert.That(checkBoxPage.FirstCheckBoxElement.Checked, Is.False);
            Thread.Sleep(3000);
            checkBoxPage.SecondCheckBoxElement.UnCheck();
            Assert.That(checkBoxPage.FirstCheckBoxElement.Checked, Is.False);
            Thread.Sleep(3000);
            checkBoxPage.AddRadioButtonsToThePage();
            Thread.Sleep(3000);
            checkBoxPage.FirstRadionButtonElement.Element.Click();
            Assert.That(checkBoxPage.FirstRadionButtonElement.Checked, Is.True);
            Thread.Sleep(3000);
            checkBoxPage.SecondRadionButtonElement.Element.Click();
            Assert.That(checkBoxPage.FirstRadionButtonElement.Checked, Is.False);
            checkBoxPage.SecondRadionButtonElement.Element.Click();
        }

        [Test]
        public void FindElementsAndFindElement()
        {
            var webBrowser = BrowserFactory.Create();
            var site = new Pages.SampleControlSite(webBrowser);
            site.MainPage.Navigate();
            var checkBoxPage = site.MainPage.ClickOnCheckBox();

            var checkbox21 = checkBoxPage.Checkbox2;
            var checkbox22 = checkBoxPage.CheckboxDiv.FindElements<CheckBoxElement>(FindBy.TagName("input"))[1];
            Assert.That(checkbox21.Checked, Is.EqualTo(true));
            Assert.That(checkbox22.Checked, Is.EqualTo(true));
        }

        [Test]
        public void GotoCheckboxPageWithActionClick()
        {
            var webBrowser = BrowserFactory.Create();
            var site = new Pages.SampleControlSite(webBrowser);
            site.MainPage.Navigate();
            site.MainPage.CheckBox.Actions.Click();

            var checkBoxPage = new CheckBoxPage(site.MainPage.WebBrowser);

            Assert.IsTrue(checkBoxPage.CheckboxDiv.Displayed);
        }

        [Test]
        public void GotoCheckboxPageWithJavascriptClick()
        {
            var webBrowser = BrowserFactory.Create();
            var site = new Pages.SampleControlSite(webBrowser);
            site.MainPage.Navigate();
            site.MainPage.CheckBox.Javascript.Click();

            var checkBoxPage = new CheckBoxPage(site.MainPage.WebBrowser);

            Assert.IsTrue(checkBoxPage.CheckboxDiv.Displayed);
        }

        [Test]
        public void SelectDropdownItems()
        {
            using (var webBrowser = BrowserFactory.Create())
            {
                var site = new Pages.SampleControlSite(webBrowser);

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
                var site = new Pages.SampleControlSite(webBrowser);

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

        [Test]
        public void UseEnvironmentConfiguration()
        {
            Environment.SetEnvironmentVariable("BrowserType", "Firefox", EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("ServerAddress", "http://the-internet.herokuapp.com/", EnvironmentVariableTarget.Process);

            IConfiguration configuration = new EnvironmentConfiguration();

            //todo add only configuration to Create
            using (var webBrowser = BrowserFactory.Create(configuration.BrowserType))
            {
                var site = new Pages.SampleControlSite(webBrowser, configuration.ServerAddress);
                site.MainPage.Navigate();
            }
        }

        [Test]
        public void DragAndDropTest()
        {
            using (var webBrowser = BrowserFactory.Create())
            {
                var site = new SampleControlSite(webBrowser);

                var dragAndDropPage = site.DragAndDropPage;

                dragAndDropPage.Navigate();

                dragAndDropPage.RectangleA.Actions.DragAndDropTo(dragAndDropPage.RectangleB);

                //todo draganddrop is not working here
                //Assert.AreEqual("B", dragAndDropPage.RectangleA.Text);
            }
        }
    }
}