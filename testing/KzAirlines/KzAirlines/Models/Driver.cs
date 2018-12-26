using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace KzAirlines.Models
{
    public class Driver
    {
        public IWebDriver Instance;

        private static readonly Lazy<Driver> lazy =
        new Lazy<Driver>(() => new Driver());

        private Driver()
        {
            var dir = Environment.CurrentDirectory;
            var chromeDriverService = FirefoxDriverService.CreateDefaultService(dir);
            chromeDriverService.HideCommandPromptWindow = true;

            Instance = new FirefoxDriver(chromeDriverService);
            Instance.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(2));
            Instance.Manage().Window.Maximize();
        }

        public static Driver GetInstance() => lazy.Value;
    }
}
