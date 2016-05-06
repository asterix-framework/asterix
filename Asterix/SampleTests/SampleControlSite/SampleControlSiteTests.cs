using System;
using System.Threading;
using Asterix.Framework.WebUi;
using Asterix.Framework.WebUi.Browser;
using Asterix.Framework.WebUi.Elements.SpecificElements;
using NUnit.Framework;
using SampleTests.SampleControlSite.Pages;
using TestContext.Configuration;

namespace SampleTests.SampleControlSite
{
    [TestFixture]
    public class SampleControlSiteTests
    {
        [Test]
        public void CheckBoxTest()
        {
            using (var webBrowser = BrowserFactory.Create())
            {
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
        }

        [Test]
        public void FindElementsAndFindElement()
        {
            using (var webBrowser = BrowserFactory.Create())
            {
                var site = new Pages.SampleControlSite(webBrowser);
                site.MainPage.Navigate();
                var checkBoxPage = site.MainPage.ClickOnCheckBox();

                var checkbox21 = checkBoxPage.Checkbox2;
                var checkbox22 = checkBoxPage.CheckboxDiv.FindElements<CheckBoxElement>(FindBy.TagName("input"))[1];
                Assert.That(checkbox21.Checked, Is.EqualTo(true));
                Assert.That(checkbox22.Checked, Is.EqualTo(true));
                checkbox21.UnCheck();
                Assert.That(checkbox22.Checked, Is.EqualTo(false));

                Thread.Sleep(2000);
            }
        }

        [Test]
        public void GotoCheckboxPageWithActionClick()
        {
            using (var webBrowser = BrowserFactory.Create())
            {
                var site = new Pages.SampleControlSite(webBrowser);
                site.MainPage.Navigate();
                site.MainPage.CheckBox.Actions.Click();

                var checkBoxPage = new CheckBoxPage(site.MainPage.WebBrowser);

                Assert.IsTrue(checkBoxPage.CheckboxDiv.Displayed);
            }
        }

        [Test]
        public void GotoCheckboxPageWithJavascriptClick()
        {
            using (var webBrowser = BrowserFactory.Create())
            {
                var site = new Pages.SampleControlSite(webBrowser);
                site.MainPage.Navigate();
                site.MainPage.CheckBox.Javascript.Click();

                var checkBoxPage = new CheckBoxPage(site.MainPage.WebBrowser);

                Assert.IsTrue(checkBoxPage.CheckboxDiv.Displayed);
            }
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
                var site = new Pages.SampleControlSite(webBrowser);

                var dragAndDropPage = site.DragAndDropPage;

                dragAndDropPage.Navigate();

                dragAndDropPage.RectangleA.Actions.DragAndDropTo(dragAndDropPage.RectangleB);

                //todo draganddrop is not working here
                //Assert.AreEqual("B", dragAndDropPage.RectangleA.Text);
            }
        }

        [Test]
        public void GetImmediateDescandant()
        {
            using (var webBrowser = BrowserFactory.Create())
            {
                var site = new Pages.SampleControlSite(webBrowser);

                var mainPage = site.MainPage;

                mainPage.Navigate();
                var divs = mainPage.ImmediateDescandantDivs;

                Assert.That(divs.Count, Is.EqualTo(3));
            }
        }

        [Test]
        public void FindAbTestLinkByAttribute()
        {
            using (var webBrowser = BrowserFactory.Create())
            {
                var site = new Pages.SampleControlSite(webBrowser);

                var mainPage = site.MainPage;

                mainPage.Navigate();

                var abTestLink = mainPage.ContentDiv.FindElements(FindBy.Attribute("href", "/abtest"));

                Assert.That(abTestLink.Count, Is.EqualTo(1));
            }
        }
    }
}