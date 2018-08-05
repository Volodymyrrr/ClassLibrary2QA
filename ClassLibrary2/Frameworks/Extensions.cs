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


namespace ClassLibrary2.Extensions
{
    public static class Element_Extensions
    {
        

        public static bool IsDisplayed(this IWebElement element, string elementName)
        {
            bool result;
            try
            {
                result = element.Displayed;
                Console.WriteLine(elementName + " is Displayed.");
            }
            catch (Exception)
            {
                result = false;
                Console.WriteLine(elementName + " is not displayed");
            }
            return result;
        }

        internal static void LoginViaExtentions()
        {
            throw new NotImplementedException();
        }

        public static void ClickOnIt(this IWebElement element, string elementName)
        {
            element.Click();
            Console.WriteLine("Clicked on " + elementName);
        }

        public static void EnterText(this IWebElement element, string text, string elementName)
        {

            element.Clear();
            element.SendKeys(text);
            Console.WriteLine(text + " entered in the " + elementName + " field.");
        }
        public static void SelectByText(this IWebElement element, string text, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(text);
            Console.WriteLine(text + " text selected on " + elementName);
        }

        public static void SelectByIndex(this IWebElement element, int index, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByIndex(index);
            Console.WriteLine(index + " index selected on " + elementName);
        }

        public static void SelectByValue(this IWebElement element, string text, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByValue(text);
            Console.WriteLine(text + " value selected on " + elementName);
        }
       

        public class StartPage
        {
            [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/ul/li[1]/p[2]/input")]
            [CacheLookup]
            private IWebElement IsDisplayedStartPage { get; set; }

           /* public void LoginViaExtentions()
            {
                //Here we are just passing the WebElement Name, so that it can be used in the Logs
                IsDisplayedStartPage.IsDisplayed("LoginInput");
            }
            */
            [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/ul/li[1]/input")]
            [CacheLookup]
            private IWebElement Password { get; set; }
           /* public void IsDisplayedPassword()
            {
                //Here we are just passing the WebElement Name, so that it can be used in the Logs
                IsDisplayedStartPage.IsDisplayed("Password");
            }
            */

            [FindsBy(How = How.XPath, Using = "//input[@value='Увійти']")]
            [CacheLookup]
            private IWebElement Submit { get; set; }
            public IWebElement UserName { get; private set; }
            public void LoginToApplication(string testName)
            {
                var userData = Configs.GetTestData(testName);
                Configs.GetConfig();
                UserName.EnterText(Configs.Username, "Username");
                Password.EnterText(Configs.Password, "Password");
                Submit.ClickOnIt("Submit Button");
            }

        }
    }
}



    
