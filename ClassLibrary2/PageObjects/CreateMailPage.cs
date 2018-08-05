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
    class CreateMailPage
    {
        public IWebDriver driver;
        public CreateMailPage(IWebDriver driver) => this.driver = driver;
        public IWebElement ForWhomeLink => driver.FindElement(By.XPath("//div[@class='field_name']/descendant::span[text()='Кому:']"));
        public IWebElement SaveButton => driver.FindElement(By.XPath("//p[@class='send_container']/descendant::input[@value ='Зберегти чернетку']"));
        public IWebElement ForWhome => driver.FindElement(By.Name("to"));
        public IWebElement Subject => driver.FindElement(By.Name("subject"));
        public  IWebElement LetterText => driver.FindElement(By.XPath("//div[@class='text_editor_browser']/textarea[@name='body']"));
        public IWebElement UploadLiink => driver.FindElement(By.XPath("//*[@id='att']/div[2]/span[1]"));
        public IWebElement ChooseFileButton => driver.FindElement(By.XPath("//input[@type='file']"));
        public IWebElement LetterButton => driver.FindElement(By.XPath("//a[text()='Листи']"));
        public void SendKeysForWhome(string ForWhome)
        {
            driver.FindElement(By.Id("to")).SendKeys(ForWhome);
        }
        
        private void SendKeysSubjectField(string Subject)
        {
            driver.FindElement(By.Name("subject")).SendKeys(Subject);
        }

        
        private void SendKeysLetterText(string LetterText)
        {
            driver.FindElement(By.XPath("//div[@class='text_editor_browser']/textarea[@name='body']")).SendKeys(LetterText);
        }


        private InboxPage SaveToDrafts ()
        {
            driver.FindElement(By.XPath("//p[@class='send_container']/input[@value ='Зберегти чернетку']")).Click();
            return new InboxPage(driver);
        }

       

        public IWebElement ForWhomeField => driver.FindElement(By.Id("to"));

        public IWebElement SubjectField => driver.FindElement(By.Name("subject"));
        public IWebElement LetterTextField => driver.FindElement(By.XPath("//div[@class='text_editor_browser']/textarea[@name='body']"));

        public IWebElement GetForWhome()
        {
            return driver.FindElement(By.Name("to"));
        }


    }
}
