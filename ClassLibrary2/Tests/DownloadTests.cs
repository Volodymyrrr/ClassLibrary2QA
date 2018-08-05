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
    class DownloadTests : TestBase
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

        }
        
        [TearDown]
        public void  SaveInDrafts()
        {
            try
            {
                createPage = new CreateMailPage(driver);

                //Assert.IsTrue(createPage.LetterButton.Displayed);
                createPage.LetterButton.Click();
              // return new InboxPage(driver);
            }
            catch ( OpenQA.Selenium.NoSuchElementException)
            {
               // Console.WriteLine("Ошибка: " + ex.Message);
                draftsPage = new DraftsPage(driver);
                //Thread.Sleep(2000);
                draftsPage.InboxLetter.Click();
                //InboxPage inboxPage = draftsPage.OpenInboxLetters();
                //InboxPage DraftsPage.OpenInboxLetters();
              // return new InboxPage(driver);
            }
          
           // LetterButton.Click();
            //createPage = new CreateMailPage(driver);
            //createPage.SaveButton.Click();
            // InboxPage inboxPage = new InboxPage(driver);
            // inboxPage.OpenDrafts();
            //IWebElement OpenDrafts = driver.FindElement(By.XPath("//span[text()='" + Name + "']"));
            //OpenDrafts.Click();

        }
        [OneTimeTearDown]
        public void DriverQuite()
       {
            InboxPage inboxPage = new InboxPage(driver);
            //рпропропропорпорпопорп
            inboxPage.OpenDrafts();
            DraftsPage draftsPage = new DraftsPage(driver);
            draftsPage.DeleteDrafts();
            Thread.Sleep(2000);
            driver.Quit();
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals("Failed"))
            {
                inboxPage.TakesScreenshot();
            }

        }



        [Test]
        public void UpLoad()
        {
            inboxPage = new InboxPage(driver);
            inboxPage.SubmitCreateMailPage();
            createPage = new CreateMailPage(driver);
            createPage.UploadLiink.Click();
            string File = "складні запити.xlsx";
            string FilePath = @"D:\Magnis\медіатека\" + File;//задаємо шлях до файлу
            Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(800));
            wait.Until(p => driver.FindElement(By.XPath("//input[@type='file']")).Displayed);
            createPage.ChooseFileButton.SendKeys(FilePath);
            createPage.SaveButton.Click();
            DraftsPage draftPage = inboxPage.OpenDrafts();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            Thread.Sleep(3000);
            string title = TestContext.CurrentContext.Test.Name;
            string runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            string filePath = @"C:\Temp\";
            ss.SaveAsFile(filePath + runname + ".jpg", ScreenshotImageFormat.Jpeg);

            string expectedAttachment = draftPage.GetAttachment(File).GetAttribute("title");
            Assert.IsTrue(expectedAttachment.Contains(File));
           
        }
        [Test]
        public void zDownLoad()
        {
            //InboxPage inboxPage = Navigator.OpenInboxPage(driver);
            //inboxPage.OpenDrafts();
            inboxPage = new InboxPage(driver);
            DraftsPage draftPage = inboxPage.OpenDrafts();
            draftPage.CreatedDraft.Click();
           ChromeOptions chromeOptions = new ChromeOptions();
         string File = "складні запити.xlsx";
          string FilePath = @"//*[@id='attached']/li/b/a";//задаємо шлях до файлу
            chromeOptions.AddUserProfilePreference("download.default_directory",FilePath);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            //Thread.Sleep(3000);
            //string title = TestContext.CurrentContext.Test.Name;
            //string runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            //string filePath = @"C:\Temp\";
            //ss.SaveAsFile(filePath + runname + ".jpg", ScreenshotImageFormat.Jpeg);
            //ChromeDriver driver = new ChromeDriver(chromeOptions);
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText(File)).Click();
           
        }

      /*  [Test]
        public void TakeScreenshot ()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            string title = TestContext.CurrentContext.Test.Name;
            string runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            string filePath = @"D:\ScreenShot\";


            ss.SaveAsFile(filePath + runname + ".jpg", ScreenshotImageFormat.Jpeg);

        }
        */

    }
}