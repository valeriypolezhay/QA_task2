using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Auto_dz2
{

    class FirstTest
    {
        IWebDriver driver;
        IWebElement
            emailField,
            emailNextButton,
            passwordField,
            passwordNextButton,
            notificationError;

        string wrongEmailLogin = "examplemail@gmail.com";
        string wrongEmailPassword = "example_pass";
        string expectedText = "Неправильний пароль. Повторіть спробу або натисніть \"Не пам’ятаю пароль\", щоб скинути його.";


        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
            driver.Url = "https://accounts.google.com";

        }


        [Test]
        public void test()
        {


            emailField = driver.FindElement(By.XPath("//*[@id='identifierId']"));
            emailField.SendKeys(wrongEmailLogin);

            emailNextButton = driver.FindElement(By.XPath("//*[@id='identifierNext']"));
            emailNextButton.Click();

            Thread.Sleep(3000);

            passwordField = driver.FindElement(By.XPath("//*[@id='password']/div[1]/div/div[1]/input"));
            passwordField.SendKeys(wrongEmailPassword);

            passwordNextButton = driver.FindElement(By.XPath("//*[@id='passwordNext']"));
            passwordNextButton.Click();

            Thread.Sleep(1000);

            notificationError = driver.FindElement(By.XPath("//*[@id='password']/div[2]/div[2]/div"));
            string resultText = notificationError.Text;

            Assert.IsTrue(resultText.Contains(expectedText), "no");

        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

    }


}
