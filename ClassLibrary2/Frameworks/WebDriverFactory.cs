using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;


namespace ClassLibrary2.Frameworks
{
    class WebDriverFactory
    {
        public const string chrome = "CH";
        public const string firefox = "FF";
        public const string internetExplorer = "IE";
        private static IWebDriver driver = null;
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                Configs configs = Configs.GetConfig();

                if (Configs.Browser == chrome)
                {

                    return new ChromeDriver();
                }
                else if (Configs.Browser == firefox)
                {


                    return new FirefoxDriver();
                }
                else if (Configs.Browser == internetExplorer)
                {


                    return new InternetExplorerDriver();
                }
                else
                {


                    throw new Exception("Not valid browser in configss");
                }


            }

            return driver;
        }

    }
}

