using System;
using System.Net.Http.Headers;

namespace TestContext
{
    public class TestContext : IDisposable
    {
        public WebUi _webUi;
        
        public WebUi WebUi
        {
            get { return _webUi ?? (_webUi = new WebUi()); }
        }

        #region dispose

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _webUi.Dispose();
                }

                // shared cleanup logic
                disposed = true;
            }
        }

        ~TestContext()
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
