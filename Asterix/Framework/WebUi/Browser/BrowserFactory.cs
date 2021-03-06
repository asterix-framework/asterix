﻿using System;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace Asterix.Framework.WebUi.Browser
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        InternetExplorer,
        Edge,
        PhantomJs,
    }

    public class BrowserFactory
    {
        public static IWebBrowser Create(BrowserType browserType = BrowserType.Firefox)
        {
            IWebDriver webDriver;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    webDriver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    webDriver = new FirefoxDriver();
                    break;
                case BrowserType.InternetExplorer:
                    webDriver = new InternetExplorerDriver();
                    break;
                case BrowserType.Edge:
                    webDriver = new EdgeDriver();
                    break;
                case BrowserType.PhantomJs:
                    PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
                    service.IgnoreSslErrors = true;
                    service.HideCommandPromptWindow = true;
                    webDriver = new PhantomJSDriver(service);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }

            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            webDriver.Manage().Window.Maximize();

            return Create(webDriver);
        }

        private static IWebBrowser Create(IWebDriver webDriver)
        {
            return new WebBrowser(webDriver, new ConsoleLogger(new DatetTimeProvider()));
        }
    }
}
