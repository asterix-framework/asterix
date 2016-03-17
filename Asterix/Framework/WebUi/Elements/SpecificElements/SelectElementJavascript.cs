using System.Text;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public class SelectElementJavascript
    {
        private readonly IWebElement _webElement;
        private readonly IJavaScriptExecutor _javaScriptExecutor;

        public SelectElementJavascript(IWebDriver webDriver, IWebElement webElement)
        {
            _webElement = webElement;
            _javaScriptExecutor = webDriver as IJavaScriptExecutor;
        }

        public void SelectByText(string text)
        {
            var sb = new StringBuilder();
            sb.Append("for(var i=0; i < arguments[0].options.length; i++) {");
            sb.Append(string.Format("  if ( arguments[0].options[i].text == '{0}' )  {{", text));
            sb.Append("     arguments[0].selectedIndex = i;");
            sb.Append("     arguments[0].options[i].click();");
            sb.Append("     break;");
            sb.Append("   }");
            sb.Append("}");
            SelectItemByScript(sb.ToString());
        }

        public void SelectByIndex(int index)
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("arguments[0].selectedIndex ='{0}';", index));
            sb.Append(string.Format("arguments[0].options[{0}].click();", index));
            SelectItemByScript(sb.ToString());
        }

        public void SelectByValue(string value)
        {
            var sb = new StringBuilder();
            sb.Append("for(var i=0; i < arguments[0].options.length; i++) {");
            sb.Append(string.Format("  if ( arguments[0].options[i].value == '{0}' )  {{", value));
            sb.Append("     arguments[0].selectedIndex = i;");
            sb.Append("     arguments[0].options[i].click();");
            sb.Append("     break;");
            sb.Append("   }");
            sb.Append("}");
            SelectItemByScript(sb.ToString());
        }

        private void SelectItemByScript(string script)
        {
            ExecuteJavaScript(script);
            FireOnChangeEvent();
        }

        private void ExecuteJavaScript(string script)
        {
            _javaScriptExecutor.ExecuteScript(script, _webElement);
        }

        private void FireOnChangeEvent()
        {
            var sb = new StringBuilder();
            sb.Append("if ('createEvent' in document) {");
            sb.Append("   var evt = document.createEvent('HTMLEvents');");
            sb.Append("   evt.initEvent('change', false, true);");
            sb.Append("   arguments[0].dispatchEvent(evt);");
            sb.Append("}");
            sb.Append("else");
            sb.Append("   arguments[0].fireEvent('onchange');");

            ExecuteJavaScript(sb.ToString());
        }
    }
}