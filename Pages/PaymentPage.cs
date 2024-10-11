using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PayPalAutomation.Pages
{
    public class PaymentPage
    {
        private IWebDriver driver;

        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='ZCFeP1_sWAaVbm7OTkNv']/a[contains(text(), 'Send')]")]
        private IWebElement sendMoneyButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='css-mkiyeu-text_input_base-text_body']//following::input")]
        private IWebElement recipientEmailField;

        [FindsBy(How = How.Name, Using = "amount")]
        private IWebElement amountField;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Next')]")]
        private IWebElement continueButton;

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Security Challenge')]")]
        private IWebElement captcha;

        public void NavigateToSendMoney()
        {
            sendMoneyButton.Click();
        }

        public void EnterRecipient(string recipientEmail)
        {
            recipientEmailField.SendKeys(recipientEmail);
        }

        public void EnterAmount(string amount)
        {
            amountField.SendKeys(amount);
        }

        public void ClickContinue()
        {
            continueButton.Click();
        }
    }
}
