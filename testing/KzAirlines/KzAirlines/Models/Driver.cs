using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace KzAirlines.Models
{
    public class Driver : IDisposable
    {
        public IWebDriver Instance;

        public Driver()
        {
            if (Instance == null)
            {
                var dir = Environment.CurrentDirectory;
                var chromeDriverService = FirefoxDriverService.CreateDefaultService(dir);
                chromeDriverService.HideCommandPromptWindow = true;

                Instance = new FirefoxDriver(chromeDriverService);
                Instance.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(2));
                Instance.Manage().Window.Maximize();
            }
            else
                throw new InvalidOperationException();
        }

        public void Dispose()
        {
            Instance.Quit();
            Instance.Dispose();
            Instance=null;
        }
    }
}
