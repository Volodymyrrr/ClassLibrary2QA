using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using ClassLibrary2.PageObjects;
using ClassLibrary2.Frameworks;


namespace ClassLibrary2.Tests
{
    [TestFixture]
    class VolodymyrTests : TestBase
    {
        StartPage startPage;
        LoginPageObject loginPageObject;

        [SetUp]
        public override void SetUp()
        {
            startPage = Navigator.NavigateToIUA(driver);
            

        }


        [Test]
        public void LoginWithWrongCredentials()
        {
            startPage.LoginInput.SendKeys("incorrectlogin");
            startPage.PassInput.SendKeys("incorrectpassword");
            startPage.SelectDomain.SelectByText("ua.fm");
            startPage.LabelRemember.Click();
            startPage.SendButton.Click();
            loginPageObject = new LoginPageObject(driver);
            Assert.AreEqual(driver.Title, "Паспорт - I.UA ");
            Assert.IsTrue(loginPageObject.WrongLoginPasswordLabel.Displayed);



        }

    

    }
}
