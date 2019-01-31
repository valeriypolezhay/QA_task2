using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace Auto_dz2
{
   
    class FirstTest
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            
            driver = new ChromeDriver();
        }



        [Test]
        public void test()
        {
            driver.Url = "https://accounts.google.com";
        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

    }
     
   
}
