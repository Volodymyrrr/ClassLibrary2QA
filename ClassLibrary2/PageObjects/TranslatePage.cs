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

    class TranslatePage
    {
        public IWebDriver driver;
        public TranslatePage(IWebDriver driver) => this.driver = driver;
        public IWebElement FirstTextArea => driver.FindElement(By.Id("first_textarea"));
        public IWebElement SecondTextArea => driver.FindElement(By.Id("second_textarea"));
        public IWebElement TranslateButton => driver.FindElement(By.Name("commit"));
        public IWebElement LangSelectFrom => driver.FindElement(By.Id("first_lang_selector"));
        public IWebElement LangSelectTo => driver.FindElement(By.Id("second_lang_selector"));

        public IWebElement popupFrom => driver.FindElement(By.XPath("//*[@id='popup_language_menu_1']/ul/li[1]"));
        public IWebElement popupTo => driver.FindElement(By.XPath("//*[@id='popup_language_menu_2']"));


        
     
        public void Translate(string langFrom, string langTo)
        {
            LangSelectFrom.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(p => popupFrom.Displayed);

            driver.FindElement(By.XPath("//div[@id='popup_language_menu_1']//a[text()='" + langFrom + "']")).Click();
        
            LangSelectTo.Click();
            wait.Until(p => popupTo.Displayed);
            driver.FindElement(By.XPath("//div[@id='popup_language_menu_2']//a[text()='" + langTo + "']")).Click();
           TranslateButton.Click();
        }



    }

}
