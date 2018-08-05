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

namespace ClassLibrary2.PageObjects
{
    class DraftsPage
    {
        public IWebDriver driver;
        internal readonly object InboxLetters;

        public DraftsPage(IWebDriver driver) => this.driver = driver;
        public IWebElement Drafts => driver.FindElement(By.XPath("//a[contains(., 'Чернетки')]"));
        public IWebElement InboxLetter => driver.FindElement(By.XPath("//a[contains(., 'Вхідні')]"));
        public IWebElement AllDraftsCheck => driver.FindElement(By.XPath("//*[@id='mesgList']/div/span[1]/span[1]/input"));
        public IWebElement DeleteDraftsButton => driver.FindElement(By.XPath("//*[@id='fieldset1']/fieldset[3]/span"));
        public IWebElement Attachment => driver.FindElement(By.XPath("//*[@id='mesgList']/form/div/span/i[2]"));
        public IWebElement CreatedDraft => driver.FindElement(By.XPath("//*[@id='mesgList']/form/div/a"));
        public IWebElement GetDraftSubject(string Subject)
        {
return driver.FindElement(By.XPath("//div[@class='row new']//span[contains(text(), '" + Subject+"')]"));
        }
        public IWebElement GetAttachment(string File)
        {
            return driver.FindElement(By.XPath("//i[@class='a ext_xlsx']"));
        }

        public IWebElement GetDraftForWhome(string ForWhome)
        {
            return driver.FindElement(By.XPath("//span[contains(text(), '" + ForWhome + "')]"));
        }
public IWebElement GetDraftLetterText(string LetterText)
        {
            return driver.FindElement(By.XPath("//textarea[contains(text(), '"+ LetterText+ "')]"));
        }
        /*public InboxPage OpenInboxLetters()
        {
            InboxLetter.Click();
            return new InboxPage(driver);
        }*/

        public DraftsPage DeleteDrafts()
        { 
            try
            {
                Assert.IsTrue(AllDraftsCheck.Displayed);
                AllDraftsCheck.Click();
                DeleteDraftsButton.Click();
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                return new DraftsPage(driver);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                return new DraftsPage(driver);
            }

           /* AllDraftsCheck.Click();
            DeleteDraftsButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            return new DraftsPage(driver);
            */

        }   



    }
}
