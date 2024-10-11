using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PayPalAutomation.Base;
using PayPalAutomation.Pages;
using System;

namespace PayPalAutomation.Tests
{
    public class PayPalPaymentTests : BaseTest
    {
        [Test]
        public void TestPaymentFlow()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            string email = "faizanmf.5252@gmail.com";
            string password = "Paypal@123";
            string recipientEmail = "recipient@example.com";
            string amount = "10.00";
            try
            {
                IWebElement element = driver.FindElement(By.XPath("//h1[contains(text(),'Security Challenge')]"));
                bool isDisplayed = element.Displayed;                
            }
            catch (NoSuchElementException)
            {                
                Console.WriteLine("Element not found.");
            }
            
            loginPage.EnterEmail(email);
            loginPage.EnterPassword(password);
            paymentPage.NavigateToSendMoney();
            paymentPage.EnterRecipient(recipientEmail);
            paymentPage.EnterAmount(amount);
            paymentPage.ClickContinue();

        }
    }
}
