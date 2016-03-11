using System;
using Asterix.Framework.WebUi.Browser;

namespace TestContext
{
    public class WebUi : IDisposable
    {
        public IWebBrowser WebBrowser { get; set; }

        public WebUi()
        {
            WebBrowser = BrowserFactory.Create();
        }

        #region dispose

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    WebBrowser.Dispose();
                }

                // shared cleanup logic
                disposed = true;
            }
        }

        ~WebUi()
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