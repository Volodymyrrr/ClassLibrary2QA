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
using ClassLibrary2.Extensions;
using ClassLibrary2.Frameworks;


namespace ClassLibrary2.Tests
{
    class CreateLetterTests : TestBase
    {
        private object webdriver;
        string Name;
        StartPage startPage;
        CreateMailPage createPage;
        InboxPage inboxPage;
        DraftsPage draftsPage;


        public override void OneTimeSetUp()
        {

            InboxPage inboxPage = Navigator.OpenInboxPage(driver);
            inboxPage.OpenDrafts();
            DraftsPage draftsPage = new DraftsPage(driver);
            draftsPage.DeleteDrafts();
            inboxPage.SubmitCreateMailPage();

        }


        [TearDown]
        public void SaveInDrafts()
        {
            //createPage = new CreateMailPage(driver);
            //createPage.SaveButton.Click();
            InboxPage inboxPage = new InboxPage(driver);
            inboxPage.OpenDrafts();
            IWebElement OpenDrafts = driver.FindElement(By.XPath("//span[text()='" + Name + "']"));
            OpenDrafts.Click();

        }



        [TestCase("TeMa")]
        [Test]
        public void EditgSubject(string Subject)
        {


            createPage = new CreateMailPage(driver);
            createPage.SubjectField.SendKeys(Subject);
           
            createPage.SaveButton.Click();
            InboxPage inboxPage = new InboxPage(driver);

            DraftsPage draftPage = inboxPage.OpenDrafts();

            Name = Subject;
            IWebElement Element = draftPage.GetDraftSubject(Subject);
            string expectedSubject = draftPage.GetDraftSubject(Subject).Text;

            Assert.AreEqual("TeMa", draftPage.GetDraftSubject(Subject).Text);
            /*inboxPage.SubmitCreateMailPage();
            inboxPage.OpenDrafts();
            IWebElement OpenDrafts = driver.FindElement(By.XPath("//span[text()='" + Name + "']"));*/
        }

        [TestCase("roxolana.yatsun@gmai.com")]

        [Test]
        public void EditForWhome(string ForWhome)

        {

            createPage = new CreateMailPage(driver);
            createPage.ForWhomeField.SendKeys(ForWhome);
            createPage.SaveButton.Click();
            InboxPage inboxPage = new InboxPage(driver);

            DraftsPage draftPage = inboxPage.OpenDrafts();

            Name = ForWhome;

            IWebElement Element = draftPage.GetDraftForWhome(ForWhome);
            string expectedFromWhome = draftPage.GetDraftForWhome(ForWhome).Text;

            Assert.AreEqual(ForWhome, draftPage.GetDraftForWhome(ForWhome).Text);
            //inboxPage.SubmitCreateMailPage();
        }


        [TestCase("roxolana.yatsun@gmai.com","У мене вийшло!")]

         [Test]
         public void EditLetterText(string ForWhome, string LetterText)
         {
             createPage = new CreateMailPage(driver);
            createPage.ForWhomeField.SendKeys(ForWhome);
            createPage.LetterTextField.SendKeys(LetterText);
             createPage.SaveButton.Click();
             InboxPage inboxPage = new InboxPage(driver);
             DraftsPage draftPage = inboxPage.OpenDrafts();
             Name = ForWhome;

            IWebElement OpenDrafts = driver.FindElement(By.XPath("//span[text()='" + Name + "']"));
            OpenDrafts.Click();

            IWebElement Element = draftPage.GetDraftLetterText(LetterText);
             string expectedLetterText = draftPage.GetDraftLetterText(LetterText).Text;

             Assert.AreEqual(LetterText+ "\r\n", draftPage.GetDraftLetterText(LetterText).GetAttribute("value"));
            createPage.SaveButton.Click();
            //  inboxPage.OpenDrafts();
            // IWebElement OpenDrafts = driver.FindElement(By.XPath("//span[text()='" + Name + "']"));

        }
         
    }
}
//        [OneTimeTearDown]
//        public void DriverQuite()
//        {            
//            driver.Quit();
//        }

//    }
//}
/*
    [TestCase("roxolana.yatsun@gmai.com", "Мій автотест", "У мене вийшло!")]
        public void SaveFirstMail(string ForWhome, string Subject, string LetterText)
        {

            InboxPage inboxPage = new InboxPage(driver);
            inboxPage.SubmitCreateMailPage();

            CreateMailPage createPage = new CreateMailPage(driver);
            createPage.ForWhomeField.SendKeys(ForWhome);
            createPage.SubjectField.SendKeys(Subject);                      
            createPage.LetterTextField.SendKeys(LetterText);
            createPage.SaveButton.Click();

          
            inboxPage.Drafts.Click();

            IWebElement CreatedLetter = driver.FindElement(By.XPath("//span[text()='Мій автотест']"));
            CreatedLetter.Click();

            
            Assert.AreEqual(ForWhome, createPage.ForWhomeField.GetAttribute("value"));
            Assert.AreEqual(Subject, createPage.SubjectField.GetAttribute("value"));
            Assert.AreEqual(LetterText+ "\r\n", createPage.LetterTextField.GetAttribute("value"));
        }       


        /*[Test]
        public void CorrectDraft ()
        {

            InboxPage inboxPage = new InboxPage(driver);
            inboxPage.Drafts.Click();

            IWebElement CreatedLetter = driver.FindElement(By.XPath("//span[text()='Мій автотест']"));
            CreatedLetter.Click();

            CreateMailPage createPage = new CreateMailPage(driver);
            Assert.AreEqual(ForWhome, createPage.ForWhomeField.GetAttribute("value"));
            Assert.AreEqual(Subject, createPage.SubjectField.GetAttribute("value"));
            Assert.AreEqual(LetterText, createPage.LetterTextField.GetAttribute("value"));


        }*/









