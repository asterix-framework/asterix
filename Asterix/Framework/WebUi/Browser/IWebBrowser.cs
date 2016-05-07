using System;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.Logging;

namespace Asterix.Framework.WebUi.Browser
{
    public interface IWebBrowser: IElementBase, IDisposable
    {
        bool IsClosed { get; }
        string Html { get; }
        Uri ServerAddress { get; set; }

        void ExecuteJavaScript(string code, params object[] args);
        void ExecuteJavaScript(string code);
        void Navigate(string url);
        void Navigate(Uri uri);
        void Refresh();
        IWebBrowser SwitchToFrame(string frameName);
        IWebBrowser SwitchToDefaultContent();
        void Quit();
        void Close();
    }
}