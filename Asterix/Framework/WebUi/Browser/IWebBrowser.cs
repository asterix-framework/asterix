using System;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.Logging;

namespace Asterix.Framework.WebUi.Browser
{
    public interface IWebBrowser: IElementBase, IDisposable
    {
        string Html { get; }
        Uri ServerAddress { get; set; }
        void Navigate(string url);
        void Navigate(Uri uri);
        void Refresh();
        void SwitchToFrame(string frameName);
        void SwitchToMain();
        void Quit();
    }
}