using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PayPalAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement emailField;

        [FindsBy(How = How.Id, Using = "btnNext")]
        private IWebElement nextButton;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordField;

        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement loginButton;

        public void EnterEmail(string email)
        {
            emailField.SendKeys(email);
            nextButton.Click();
        }

        public void EnterPassword(string password)
        {
            passwordField.SendKeys(password);
            loginButton.Click();
        }
    }
}
