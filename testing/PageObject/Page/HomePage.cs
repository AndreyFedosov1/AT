using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AirlinesTestingApp.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private const string url = "https://airastana.com/rus/ru-ru";
        By addPassenger = By.Id("tbAdult");
        By plusBaby = By.Id("tbChild");
        By errorsMessages = By.ClassName("error");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void AddPassengers(){
            driver.FindElement(addPassenger).Click();
        }

        public void PlusBaby(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                driver.FindElement(plusBaby).Click();
            }
        }

        public IWebElement GetErrorsMessages()
        {
            return driver.FindElement(errorsMessages);
        }
    }
}
