using System;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.Exceptions;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Browser
{
    public class WebBrowser : ElementBase, IWebBrowser
    {
        private static IWebBrowser _browserInstance;
        public bool IsClosed { get; private set; }

        public WebBrowser(IWebDriver webDriver, ILogger logger)
            : base(webDriver, logger, () => webDriver.FindElement(By.XPath("//*")))
        {
        }

        public static IWebBrowser Instance
        {
            get
            {
                if (_browserInstance == null || _browserInstance.IsClosed)
                {
                    _browserInstance = BrowserFactory.Create();
                }

                return _browserInstance;
            }
        }

        public void ExecuteJavaScript(string code)
        {
            ExecuteJavaScript(code, null);
        }

        public void ExecuteJavaScript(string code, params object[] args)
        {
            ((IJavaScriptExecutor) WebDriver).ExecuteScript(code, args);
        }

        public void Navigate(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public Uri ServerAddress { get; set; }

        public void Navigate(Uri uri)
        {
            WebDriver.Navigate().GoToUrl(uri);
        }

        public void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }

        public void SwitchToFrame(string frameName)
        {
            try
            {
                WebDriver.SwitchTo().Frame(frameName);
            }
            catch (NoSuchFrameException exc)
            {
                throw new FrameNotFoundException(string.Format("Frame: {0} was not found!", frameName), exc);
            }
        }

        public void SwitchToMain()
        {
            WebDriver.SwitchTo().DefaultContent();
        }

        public string Html
        {
            get
            {
                return WebDriver.PageSource;
            }
        }

        public void Quit()
        {
            WebDriver.Quit();
            IsClosed = true;
        }

        public void Close()
        {
            WebDriver.Close();
            IsClosed = true;
        }



        #region dispose

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Quit();
                }

                // shared cleanup logic
                disposed = true;
            }
        }

        ~WebBrowser()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        #endregion
    }
}
