using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ClassLibrary2.Extensions;
using System;
using NUnit.Framework;

namespace ClassLibrary2.PageObjects
{

    class StartPage
    {

        public IWebDriver driver;
        public StartPage(IWebDriver driver) => this.driver = driver;

       // public static object LoginViaExtentions { get; internal set; }

        public IWebElement LoginInput => driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/ul/li[1]/p[2]/input"));
        public IWebElement PassInput => driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/ul/li[1]/input"));
        public IWebElement SelectDown => driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/ul/li[2]/p/select"));
        public IWebElement Check => driver.FindElement(By.Name("auth_type"));
        public IWebElement SendButton => driver.FindElement(By.XPath("//input[@value='Увійти']"));
        public IWebElement LinkButton => driver.FindElement(By.XPath("//a[text()='нагадати']"));
        public IWebElement LinkRegButton => driver.FindElement(By.XPath("//div[@class='content clear']//a[text()='Реєстрація']"));
        public IWebElement LinkMailButton => driver.FindElement(By.XPath("//div[@class='content clear']//a[text()='Пошта']"));
        public IWebElement LabelRemember => driver.FindElement(By.Name("auth_type"));
        public IWebElement RegistrationHeaderLink => driver.FindElement(By.XPath("//div[@class='Header clear']//a[text()='Реєстрація']"));
        public IWebElement NewsLink => driver.FindElement(By.XPath("//div[@class='block_gamma_gradient news']//a[text()='Новини']"));
        public IWebElement UsdRate => driver.FindElement(By.XPath("//div[@class='content clear']//th[text()='USD']"));

        public IWebElement usdRateBuy => driver.FindElement(By.XPath("//th[text()='USD']/parent::tr/td[1]"));

        public IWebElement usdRateSail => driver.FindElement(By.XPath("//th[text()='USD']/parent::tr/td[2]"));

        public IWebElement usdRateNbu => driver.FindElement(By.XPath("//th[text()='USD']/parent::tr/td[3]"));
        public IWebElement Konverter => driver.FindElement(By.XPath("//input[@value='Введіть суму']"));
        public IWebElement ExchangeSelect => driver.FindElement(By.Name("fn_c1900"));
        public IWebElement LoginOutButton => driver.FindElement(By.XPath("//a[text()='Вихід']"));

        public void SendKeysLoginInput(string Login)
        {
            driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/ul/li[1]/p[2]/input")).SendKeys(Login);
        }
        public void SendKeysPassInput(string PassWord)
        {
            driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/ul/li[1]/input")).SendKeys(PassWord);
        }

        public InboxPage LOGIN(string username, string password)
        {           
                      
          SendKeysLoginInput(username);
           SendKeysPassInput(password);
           SelectDown.Click();
           
           Check.Click();
           SendButton.Click();
                      
            return new InboxPage(driver);
        }

        private void EnterText(StartPage startPage, IWebElement webElement, IWebElement loginInput1, string v1, object username, string v2, IWebElement loginInput2)
        {
            throw new NotImplementedException();
        }
    }
}

