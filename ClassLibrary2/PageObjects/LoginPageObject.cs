using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace ClassLibrary2.PageObjects
{
    class LoginPageObject
    {
        public IWebDriver driver;
        public LoginPageObject(IWebDriver driver) => this.driver = driver;
        public IWebElement WrongLoginPasswordLabel => driver.FindElement(By.XPath("//div[contains(text(),'Невірний логін або пароль')]"));



    }
}
