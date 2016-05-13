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

        public MainPage MainPage => new MainPage(_webBrowser);

        public DropDownPage DropDownPage => new DropDownPage(_webBrowser);

        public CheckBoxPage CheckBoxPage => new CheckBoxPage(_webBrowser);

        public DragAndDropPage DragAndDropPage => new DragAndDropPage(_webBrowser);

        public FramePage FramePage => new FramePage(_webBrowser);
    }
}
