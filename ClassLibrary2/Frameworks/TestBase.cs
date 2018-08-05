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


namespace ClassLibrary2.Frameworks
{
    public class TestBase
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void BaseOneTimeSetUp()
        {
            driver = WebDriverFactory.GetInstance();
            OneTimeSetUp();
        }
        public virtual void OneTimeSetUp()
        { }

        [SetUp]
        public void BaseSetUp()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine(TestContext.CurrentContext.Test.Name);
            SetUp();
        }

        public virtual void SetUp()
        {
           
        }

        [TearDown]
        public void BaseTearDown()
        {
            Console.WriteLine(TestContext.CurrentContext.Result.Outcome.Status);
            TearDown();
        }
        public virtual void TearDown()
        {
        }


        [OneTimeTearDown]
        public void BaseOneTimeTearDown()
        {
            driver.Quit();

        }


    }
}
