using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  ClassLibrary2.PageObjects;

namespace ClassLibrary2
{
    static class Navigator
    {
        public static StartPage NavigateToIUA(IWebDriver driver)
        {

            driver.Navigate().GoToUrl("http://www.i.ua/");
            return new StartPage(driver);
        }
        public static TranslatePage NavigateToTransPage(IWebDriver driver)
        {

            driver.Navigate().GoToUrl("https://perevod.i.ua/");
            return new TranslatePage(driver);
        }
        public static InboxPage OpenInboxPage(IWebDriver driver)
        {
           
            driver.Navigate().GoToUrl("http://www.i.ua/");
            StartPage startPage = new StartPage(driver);
            startPage.LOGIN(Configs.Username, Configs.Password);           
            return new InboxPage(driver);
        }
    }
}
