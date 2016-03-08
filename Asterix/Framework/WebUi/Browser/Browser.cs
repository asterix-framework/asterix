using System;
using Asterix.Core.Contracts.Logging;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.Exceptions;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Browser
{
    public class Browser : ElementBase, IBrowser
    {
        public Browser(IWebDriver webDriver, ILogger logger) : base(webDriver, logger, () => webDriver.FindElement(By.XPath("/*"))) { }
        
        public void Navigate(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

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

        ~Browser()
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
