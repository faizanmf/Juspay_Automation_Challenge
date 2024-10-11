using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PayPalAutomation.Pages;
using System;
using System.Collections.Generic;

namespace PayPalAutomation.Base
{
    public class BaseTest
    {
        public IWebDriver driver;
        public LoginPage loginPage;
        public PaymentPage paymentPage;
        

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("https://www.paypal.com/signin");
            loginPage = new LoginPage(driver);
            paymentPage = new PaymentPage(driver);
        }       

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
