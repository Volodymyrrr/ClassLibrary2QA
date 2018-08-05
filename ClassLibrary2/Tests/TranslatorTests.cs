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


namespace ClassLibrary2
    {

    [Category ("TranslateFunctionality")]

    class TranslatorTests
    {
        IWebDriver driver;
        private object webdriver;

        public object SecondTextArea { get; private set; }

        [OneTimeSetUp]

        public void TranslatorNavigate()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://perevod.i.ua/");
        }

        [TearDown]
        public void ClearField()
        {
            TranslatePage trPage = new TranslatePage(driver);
            trPage.FirstTextArea.Clear();
        }

        [TestCase("кот", "cat", "Русский", "Английский")]
        [TestCase("кіт", "cat", "Украинский", "Английский")]
        [TestCase("кіт", "un chat", "Украинский", "Французский")]

        [TestCase("кіт", "cat", "Украинский", "Английский")]
        [TestCase("пес", "dog", "Украинский", "Английский")]
        [TestCase("яблуко", "apple", "Украинский", "Английский")]
        [TestCase("груша", "pear", "Украинский", "Английский")]
        [TestCase("стіл", "table", "Украинский", "Английский")]


        public void TestTranslate(string wordFrom, string wordTo, string langFrom, string langTo)
        {
            TranslatePage trPage = new TranslatePage(driver);
            trPage.FirstTextArea.SendKeys(wordFrom);
            trPage.Translate(langFrom, langTo);           
            Assert.AreEqual(wordTo, trPage.SecondTextArea.GetAttribute("value"));
        }

        [OneTimeTearDown]
        public void DriverQuite()
        {
            driver.Quit();
        }

    }   
}
    
