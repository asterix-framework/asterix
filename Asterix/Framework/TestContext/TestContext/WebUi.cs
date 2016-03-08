using System;
using Asterix.Framework.WebUi.Browser;

namespace TestContext
{
    public class WebUi : IDisposable
    {
        public Browser Browser { get; set; }

        public WebUi()
        {
            Browser = BrowserFactory.Create(BrowserType.Firefox);
        }

        #region dispose

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Browser.Quit();
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