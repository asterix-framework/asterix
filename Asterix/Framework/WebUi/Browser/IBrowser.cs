using System;
using Asterix.Core.Contracts.Logging;
using Asterix.Framework.WebUi.Elements;

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