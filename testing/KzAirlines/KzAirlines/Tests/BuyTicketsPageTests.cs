using KzAirlines.Models;
using KzAirlines.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KzAirlines.Tests
{
    [TestClass]
    public class BuyTicketsPageTests
    {
        [TestMethod]
        public void OneCanFindTicketsFromMinskToMoscow()
        {
            using (var driver = new Driver())
            {
                var page = new BuyTicketsPage(driver.Instance);
                page.Open();
                page.InitFrom("Minsk");
                page.InitTo("Moscow");
                Assert.IsTrue(page.ResultsFound());
            }
        }

        [TestMethod]
        public void OneCantFindTicketsFromMinskToDenver()
        {
            using (var driver = new Driver())
            {
                var page = new BuyTicketsPage(driver.Instance);
                page.Open();
                page.InitFrom("Minsk");
                page.InitTo("Denver");
                Assert.IsFalse(page.ResultsFound());
            }
        }

        [TestMethod]
        public void OneCanSpecifyBackDateWhenOneWayNotSelected()
        {
            using (var driver = new Driver())
            {
                var page = new BuyTicketsPage(driver.Instance);
                page.Open();
                page.ClickOneWay();
                Assert.IsTrue(page.IsReturnDateVisible());
            }
        }

        [TestMethod]
        public void OneCantSpecifyBackDateWhenOneWaSelected()
        {
            using (var driver = new Driver())
            {
                var page = new BuyTicketsPage(driver.Instance);
                page.Open();
                Assert.IsFalse(page.IsReturnDateVisible());
            }
        }

        [TestMethod]
        public void OneCanLogin()
        {
            using (var driver = new Driver())
            {
                var page = new BuyTicketsPage(driver.Instance);
                page.Open();
                page.ClickLoginButton();
                page.EnterLogin("kadac28@gmail.com");
                page.EnterPassword("kdkddkkd1211");
                page.ClickLoginButton();
                Assert.AreEqual(expected: "ANDREY", actual: page.UserName);
                Assert.IsTrue(page.Authorized);
            }
        }

        [TestMethod]
        public void OneCanLogout()
        {
            using (var driver = new Driver())
            {
                var page = new BuyTicketsPage(driver.Instance);
                page.Open();
                page.ClickLoginButton();
                page.EnterLogin("kadac28@gmail.com");
                page.EnterPassword("kdkddkkd1211");
                page.ClickLoginButton();
                Assert.AreEqual(expected: "ANDREY", actual: page.UserName);
                page.ClickLogoutButton();
                Assert.IsFalse(page.Authorized);
            }
        }
    }
}
