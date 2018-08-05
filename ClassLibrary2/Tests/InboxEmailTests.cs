using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using ClassLibrary2.PageObjects;



namespace ClassLibrary2.Tests
{
    public class MyEmailPage
    {
        IWebDriver driver;
        private object webdriver;
        StartPage startPage;
        InboxPage inboxPage;

        [OneTimeSetUp]

        public void EmailPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");
       
      
       // InboxPage inboxPage;
      //  DeletedMails deletedMails;

       // [TestCase("roxolana.yatsun", "Aaaa12345678")]
                
            StartPage startPage = new StartPage(driver);
            startPage.SendKeysLoginInput("roxolana.yatsun");
            startPage.SendKeysPassInput("Aaaa12345678");


            startPage.SelectDown.Click();

            Assert.AreEqual("i.ua\r\nua.fm\r\nemail.ua\r\n3g.ua   \r\nfootball.ua\r\n   ", startPage.SelectDown.Text);

            startPage.Check.Click();

            Assert.IsTrue(startPage.Check.Selected);
            Assert.AreEqual("roxolana.yatsun", startPage.LoginInput.GetAttribute("value"));
            Assert.AreEqual("Aaaa12345678", startPage.PassInput.GetAttribute("value"));


            startPage.SendButton.Click();

        }

       /* public void TestTranslate(string wordFrom, string wordTo, string langFrom, string langTo)
        {
            TranslatePage trPage = new TranslatePage(driver);
            trPage.FirstTextArea.SendKeys(wordFrom);

            trPage.LangSelectFrom.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            wait.Until(p => trPage.popupFrom.Displayed);

            trPage.LangChooseFrom(langFrom);

            trPage.LangSelectTo.Click();
            wait.Until(p => trPage.popupTo.Displayed);
            trPage.LangChooseTo(langTo);

            trPage.TranslateButton.Click();

            Assert.AreEqual(wordTo, trPage.SecondTextArea.GetAttribute("value"));*/

        [Test]
        public void IfMyEmail()
        {
            InboxPage inboxPage = new InboxPage(driver);
            Assert.AreEqual(("roxolana.yatsun@i.ua"), inboxPage.MyEmail.Text);

        }


        [Test]
        public void JWelcomeEmail()
        {
            InboxPage inboxPage = new InboxPage(driver);
            Assert.AreEqual("Вхідні - I.UA ", driver.Title);
            Assert.IsTrue(inboxPage.WelcomeEmail.Displayed);
        }


        [Test]
        public void JWelcomePopup()
        {
            InboxPage inboxPage = new InboxPage(driver);
            Actions action = new Actions(driver);
            action.MoveToElement(inboxPage.WelcomeEmail).Build().Perform();                       
           
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(800));
            wait.Until(p => inboxPage.WelcomePopup.Displayed);
            
            Assert.AreEqual("Від: support@i.ua", inboxPage.PopupFrom.Text);         

            string s = inboxPage.PopupText.Text;
            Assert.IsTrue(s.Contains("Добрий день, Roxolana Yatsun."));


        }


        [Test]
        public void KWarningEmail()
        {
            InboxPage inboxPage = new InboxPage(driver);
            Assert.IsTrue(inboxPage.WarningEmail.Displayed);
        }



        [Test]
        public void LRecommendEmail()
        {
            InboxPage inboxPage = new InboxPage(driver);
            Assert.IsTrue(inboxPage.RecommendEmail.Displayed);
        }


        [Test]
        public void MHelpEmail()
        {
            InboxPage inboxPage = new InboxPage(driver);
            Assert.IsTrue(inboxPage.HelpEmail.Displayed);
        }

        [Test]
        public void NLetterDeleting()
        {
           
            InboxPage inboxPage = new InboxPage(driver);
            inboxPage.LetterCheckboxHelpEmail.Click();
            Assert.IsTrue(inboxPage.LetterCheckboxHelpEmail.Selected);
            inboxPage.DeleteLButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.Navigate().GoToUrl("http://mbox2.i.ua/list/Trash");
            DeletedMails deletedMails = new DeletedMails(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(p => deletedMails.DeletedHelpEmail.Displayed);

            Assert.IsTrue(deletedMails.DeletedHelpEmail.Displayed);

        }
        [OneTimeTearDown]
        public void DriverQuite()
        {
            driver.Quit();
        }
    }
}
