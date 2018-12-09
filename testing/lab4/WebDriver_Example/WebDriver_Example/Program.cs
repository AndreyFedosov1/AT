using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://airastana.com/rus/ru-ru";

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts();

            
            driver.FindElement(By.ClassName("ddlFrom")).SendKeys("АБЕРДИН (ABZ)");
            driver.FindElement(By.ClassName("ddlTo")).SendKeys("АЛМАТЫ (ALA)"); 
            driver.FindElement(By.Id("cbOneWay")).Click();

            driver.FindElement(By.Id("tbDeparture")).Click();
            driver.FindElement(By.XPath("//*[@ui-state-default ui-state-active='28']")).Click();
            
            driver.FindElement(By.Id("btn-find-flight")).Click();

        }
    }
}
