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
    class InboxPage
    {
        public IWebDriver driver;
        public InboxPage(IWebDriver driver) => this.driver = driver;
        public IWebElement CreateletterLink => driver.FindElement(By.XPath("//p[@class='make_message']//a[text()='Створити листа']"));
        public IWebElement Drafts => driver.FindElement(By.XPath("//a[contains(., 'Чернетки')]"));
        public IWebElement MyEmail => driver.FindElement(By.XPath("//span [@class='sn_menu_title']"));
        public IWebElement WelcomeEmail => driver.FindElement(By.XPath("//*[@id='mesgList']//span[text()='Ласкаво просимо на I.UA!']"));
        public IWebElement WelcomePopup => driver.FindElement(By.XPath("//div[@id = 'prflpudvmbox_userInfoPopUp']"));
        public IWebElement PopupFrom => driver.FindElement(By.XPath("//div[@id='prflpudvmbox_userInfoPopUp']/descendant::li[1]"));
        public IWebElement PopupText => driver.FindElement(By.XPath("//div[@id='prflpudvmbox_userInfoPopUp']/descendant::li[2]"));
        public IWebElement WarningEmail => driver.FindElement(By.XPath("//div[@class='messages']/descendant::span[text()='Обережно шахраї!']"));
        public IWebElement RecommendEmail => driver.FindElement(By.XPath("//div[@class='messages']/descendant::span[text()='Рекомендації по безпеці Вашого акаунту']"));
        public IWebElement HelpEmail => driver.FindElement(By.XPath("//div[@class='messages']/descendant::span[contains(text(),'Невелика довідка про')]"));
        public IWebElement LetterCheckboxHelpEmail => driver.FindElement(By.XPath("//span[contains(text(),'Невелика довідка про можливості пошти')]/parent::span/parent::a/preceding-sibling::span/input"));
        public IWebElement DeleteLButton => driver.FindElement(By.XPath("//span[@class='button l_r del']"));


        public CreateMailPage SubmitCreateMailPage()
        {
            CreateletterLink.Click();
            return new CreateMailPage(driver);
        }
        public DraftsPage OpenDrafts()
        {
            Drafts.Click();
            return new DraftsPage(driver);
        }
        public void TakesScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            string title = TestContext.CurrentContext.Test.Name;
            string runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            string filePath = @"C:\Temp\";


            ss.SaveAsFile(filePath + runname + ".jpg", ScreenshotImageFormat.Jpeg);

        }
    }
}
