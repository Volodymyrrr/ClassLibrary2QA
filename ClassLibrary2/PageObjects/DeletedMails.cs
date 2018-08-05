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
    class DeletedMails
    {

        public IWebDriver driver;
        public DeletedMails(IWebDriver driver) => this.driver = driver;
        public IWebElement DeletedHelpEmail => driver.FindElement(By.XPath("//div[@class='messages']/descendant::span[text()='Невелика довідка про можливості пошти']"));

    }    
}
