using Core.Models;
using OpenQA.Selenium;
using TMS_Soucedemo.Soucedemo.BaseEntities;

namespace TMS_Soucedemo.Soucedemo.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By UsernameInputBy = By.Id("user-name");
        private static readonly By PasswordInputBy = By.Id("password");
        private static readonly By LoginButtonBy = By.Id("login-button");
        private static readonly By ErrorMessageBy = By.XPath("//*[@data-test='error']");

        public LoginPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public LoginPage(IWebDriver? driver) : base(driver, false)
        {
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(LoginButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void SetUserName(string userName)
        {
            Driver.FindElement(UsernameInputBy).SendKeys(userName);
        }

        void SetPassword(string password)
        {
            Driver.FindElement(PasswordInputBy).SendKeys(password);
        }

        void ClickLoginButton()
        {
            Driver.FindElement(LoginButtonBy).Click();
        }

        public string GetErrorMessage()
        {
            return Driver.FindElement(ErrorMessageBy).Text;
        }

        public InventoryPage SuccessfulLogin(User user)
        {
            SetUserName(user.Username);
            SetPassword(user.Password);
            ClickLoginButton();
            return new InventoryPage(Driver);
        }

        public LoginPage LoginWithIncorrectPassword(User user)
        {
            SetUserName(user.Username);
            SetPassword(user.Password);
            ClickLoginButton();
            return this;
        }        
    }
}
