using System;
using Asterix.Framework.WebUi.Browser;

namespace SampleTests.SampleControlSite.Pages
{
    public class SampleControlSite
    {
        private readonly IWebBrowser _webBrowser;

        private const string ServerAddress = "http://the-internet.herokuapp.com/";

        public SampleControlSite(IWebBrowser webBrowser, string serverAddress)
        {
            _webBrowser = webBrowser;
            _webBrowser.ServerAddress = new Uri(serverAddress);
        }

        public SampleControlSite(IWebBrowser webBrowser) : this(webBrowser, ServerAddress) { }

        public MainPage MainPage { get { return new MainPage(_webBrowser); } }

        public DropDownPage DropDownPage { get { return new DropDownPage(_webBrowser); } }

        public CheckBoxPage CheckBoxPage { get { return new CheckBoxPage(_webBrowser); } }

        public DragAndDropPage DragAndDropPage { get { return new DragAndDropPage(_webBrowser); } }
}
}
