using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using ClassLibrary2.PageObjects;
using System.Xml;
using System.IO;
using System.Configuration;



namespace ClassLibrary2.Tests
{

    [TestFixture]
    public class LoginPage
    {
        IWebDriver driver;
        private object webdriver;
        StartPage startPage;
        InboxPage inboxPage;

        public object WebDriverFactory { get; private set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");
        }


        [Test]
        public void DisplayedLogin()

        /*{
            driver = WebDriverFactory.GetInstence();
            driver.IsDisplayed();
            startPage = INavigation.StartPage(driver);
        }
        //Try to use Extentions "IsDisplayed"
        */
        
        {
            StartPage startPage = new StartPage(driver);
            Assert.IsTrue(startPage.LoginInput.Displayed);
        }
        


        [Test]
        public void DisplayedPassword()
        {
            StartPage startPage = new StartPage(driver);
            Assert.IsTrue(startPage.PassInput.Displayed);
        }

        [Test]
        public void DisplayedSelect()
        {
            StartPage startPage = new StartPage(driver);
            Assert.IsTrue(startPage.SelectDown.Displayed);
        }

        [Test]
        public void DisplayedSendButton()
        {
            StartPage startPage = new StartPage(driver);
            Assert.IsTrue(startPage.SendButton.Displayed);
        }

        [Test]
        public void DisplayedLinkButton()
        {
            StartPage startPage = new StartPage(driver);
            Assert.IsTrue(startPage.LinkButton.Displayed);
        }


        [Test]
        public void DisplayedLinkRegButton()
        {

            StartPage startPage = new StartPage(driver);
            Assert.IsTrue(startPage.LinkRegButton.Displayed);

        }


        [Test]
        public void DisplayedLinkMailButton()
        {

            StartPage startPage = new StartPage(driver);
            Assert.IsTrue(startPage.LinkMailButton.Displayed);

        }

        [Test]
        public void DisplayedLabelRemember()
        {

            StartPage startPage = new StartPage(driver);
            Assert.IsTrue(startPage.LabelRemember.Displayed);

        }

        [Test ]
        public void RegistrationHeaderLink ()
        {
            StartPage startPage = new StartPage(driver);
            Assert.IsTrue(startPage.RegistrationHeaderLink.Displayed);
        }

        [Test]
        public void NewsLink()
        {
            StartPage startPage = new StartPage(driver);
            Assert.IsTrue(startPage.NewsLink.Displayed);
        }


        [Test]
        public void DisplayedUSDTable()
        {
            StartPage startPage = new StartPage(driver);
            Assert.IsTrue(startPage.UsdRate.Displayed);
            Assert.IsTrue(startPage.usdRateBuy.Displayed);
            Assert.IsTrue(startPage.usdRateSail.Displayed);
            Assert.IsTrue(startPage.usdRateNbu.Displayed);
            Assert.IsTrue(startPage.Konverter.Displayed);
            Assert.IsTrue(startPage.ExchangeSelect.Displayed);

        }


        [Test]
        public void TestInputLoginPass()
        {
            StartPage startPage = new StartPage(driver);
            startPage.SendKeysLoginInput("roxolana.yatsun");
            startPage.SendKeysPassInput("Aaaa12345678");
            startPage.SelectDown.Click();
            Assert.AreEqual("i.ua\r\nua.fm\r\nemail.ua\r\n3g.ua   \r\nfootball.ua\r\n   ", startPage.SelectDown.Text);
            startPage.Check.Click();

            Assert.IsTrue(startPage.Check.Selected);
            Assert.AreEqual(("roxolana.yatsun"), startPage.LoginInput.GetAttribute("value"));
            Assert.AreEqual(("Aaaa12345678"), startPage.PassInput.GetAttribute("value"));

            startPage.SendButton.Click();
            Assert.AreEqual("Вхідні - I.UA ", driver.Title);
            
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
       
   
}


