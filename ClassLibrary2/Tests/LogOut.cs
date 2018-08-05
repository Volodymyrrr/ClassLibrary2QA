using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ClassLibrary2.PageObjects;


namespace ClassLibrary2.Tests
{
    public class LogOut
    {
        IWebDriver driver;
        private object webdriver;
        

        [Test]
        //про про про про про про про 
        public void LogOutTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");
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

            string FirstWindow = driver.CurrentWindowHandle;

            IWebElement WebsiteLogo = driver.FindElement(By.XPath("//a[@class='ho_logo']"));
            WebsiteLogo.SendKeys(Keys.Control + Keys.Return);

            string SecondWindow = driver.CurrentWindowHandle;

            //вавачваівпвернокенкен
            var Windows = driver.WindowHandles;
            foreach (var Window in Windows)
            {
                if (Window != FirstWindow)
                    SecondWindow = Window;
                driver.SwitchTo().Window(SecondWindow);
            }

            string title = driver.Title;

            
            startPage.LoginOutButton.Click();

            driver.SwitchTo().Window(FirstWindow);

            driver.Navigate().Refresh();

            Assert.AreNotEqual("Вхідні - I.UA ", driver.Title);

        }
        [OneTimeTearDown]
        public void DriverQuite()
        {
            driver.Quit();
        }
    }
}
