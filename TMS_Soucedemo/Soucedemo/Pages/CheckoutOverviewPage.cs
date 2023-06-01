using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Soucedemo.Soucedemo.BaseEntities;

namespace TMS_Soucedemo.Soucedemo.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        private static string END_POINT = "checkout-step-two.html";

        private static readonly By FinishButtonBy = By.Id("finish");
        

        public CheckoutOverviewPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutOverviewPage(IWebDriver? driver) : base(driver, false)
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
                return Driver.FindElement(FinishButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void ClickFinishButton()
        {
            Driver.FindElement(FinishButtonBy).Click();
        }

        public CheckoutCompletePage GoToCheckoutCompletePage()
        {
            ClickFinishButton();
            return new CheckoutCompletePage(Driver);
        }
    }
}
