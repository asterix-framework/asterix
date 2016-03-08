using System;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.Logging;

namespace Asterix.Framework.WebUi.Browser
{
    public interface IBrowser: IDisposable
    {
        ILogger Logger { get; }
        string Html { get; }
        void Navigate(string url);
        void Navigate(Uri uri);
        void Refresh();
        IElement FindElement(FindBy by);
        void SwitchToFrame(string frameName);
        void SwitchToMain();
        void Quit();
    }
}