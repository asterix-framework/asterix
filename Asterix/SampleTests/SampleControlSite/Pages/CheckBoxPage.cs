using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asterix.Framework.WebUi;
using Asterix.Framework.WebUi.Browser;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.Elements.SpecificElements;
using Asterix.Framework.WebUi.PageObject;
using OpenQA.Selenium;

namespace SampleTests.SampleControlSite.Pages
{
    public class CheckBoxPage :PageBase
    {
        private const string Radiobutton1 = "radiobutton1";
        private const string Radiobutton2 = "radiobutton2";

        public CheckBoxPage(IWebBrowser webBrowser) : base(webBrowser)
        {
        }

        protected override string PageUrl => "checkboxes";

        public ICheckBoxElement FirstCheckBoxElement
        {
            get
            { 
                return WebBrowser.FindElement<CheckBoxElement>(FindBy.XPath("//*[@id=\"checkboxes\"]/input[1]"));
            }
        }
        public ICheckBoxElement SecondCheckBoxElement
        {
            get
            {  
                return WebBrowser.FindElement<CheckBoxElement>(FindBy.XPath("//*[@id=\"checkboxes\"]/input[2]"));
            }
        }

        public IRadioButtonElement FirstRadionButtonElement
        {
            get
            { 
                return WebBrowser.FindElement<RadionButtonElement>(FindBy.Id(Radiobutton1));
            }
        }

        public IRadioButtonElement SecondRadionButtonElement
        {
            get
            { 
                return WebBrowser.FindElement<RadionButtonElement>(FindBy.Id(Radiobutton2));
            }
        }

        public IElement CheckboxDiv
        {
            get
            {
                return WebBrowser.FindElements(FindBy.Class("row"))[1];
            }
        }

        public IElement CheckboxForm
        {
            get { return CheckboxDiv.FindElement(FindBy.Id("checkboxes")); }
        }

        public ICheckBoxElement Checkbox2
        {
            get { return CheckboxForm.FindElements<CheckBoxElement>(FindBy.TagName("input"))[1]; }
        }

        public CheckBoxPage AddRadioButtonsToThePage()
        {
            AddRadioButton(Radiobutton1);
            AddRadioButton(Radiobutton2);
            return this;
        }

        private void AddRadioButton(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("var br = document.createElement('br');");
            sb.Append("var form = document.getElementById('checkboxes');");
            sb.Append("form.appendChild(br);");
            sb.Append("var radioYes = document.createElement('input');");
            sb.Append("radioYes.setAttribute('type', 'radio');");
            sb.Append("radioYes.setAttribute('id', '" + id + "');");
            sb.Append("radioYes.setAttribute('name', 'radiobuttons');");
            sb.Append("form.appendChild(radioYes);");
            sb.Append("var text = document.createTextNode(' " + id + "');");
            sb.Append("form.appendChild(text);");
            WebBrowser.ExecuteJavaScript(sb.ToString());

       }
    }
}
