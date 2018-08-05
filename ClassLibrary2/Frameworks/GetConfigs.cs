using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Configuration;
using System.Xml;

namespace ClassLibrary2
{
    public  class Configs
    {
        public static string Browser;       
        public static string Username;
        public static string Password;
        public static string Environment;



        public static Configs GetConfig()
        {
            string executingAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = new DirectoryInfo(executingAssembly).Parent.Parent.Parent.FullName;
            var pathtoconfig = Path.Combine(path + @"\Frameworks\", "Configs.xml");

   
                XmlDocument xmlDoc = new XmlDocument();
 
                xmlDoc.Load(pathtoconfig);
                Browser = xmlDoc.DocumentElement.SelectSingleNode("browser").InnerText;
                Username = xmlDoc.DocumentElement.SelectSingleNode("username").InnerText;
                Password = xmlDoc.DocumentElement.SelectSingleNode("password").InnerText;

                return new Configs();

        }

        internal static object GetTestData(string testName)
        {
            throw new NotImplementedException();
        }
    }
}