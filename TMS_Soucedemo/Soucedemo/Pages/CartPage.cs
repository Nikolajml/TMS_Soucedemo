using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Soucedemo.Soucedemo.BaseEntities;

namespace TMS_Soucedemo.Soucedemo.Pages
{
    public class CartPage : BasePage
    {
        private static string END_POINT = "cart.html";

        private static readonly By RemoveButtonBy = By.Id("remove-sauce-labs-backpack");
        private static readonly By CheckoutButtonBy = By.Id("checkout");        

        public CartPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CartPage(IWebDriver? driver) : base(driver, false)
        {

        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(RemoveButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void ClickToCheckoutButton()
        {
            Driver.FindElement(CheckoutButtonBy).Click();
        }

        public CheckoutYourInformation GoToCheckoutPage()
        {
            ClickToCheckoutButton();
            return new CheckoutYourInformation(Driver);
        }
    }
}
