using Bogus.DataSets;
using Core.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Soucedemo.Soucedemo.BaseEntities;

namespace TMS_Soucedemo.Soucedemo.Pages
{
    public class CheckoutYourInformation : BasePage
    {
        private static string END_POINT = "checkout-step-one.html";

        private static readonly By FirstNameInputBy = By.Id("first-name");
        private static readonly By LastNameInputBy = By.Id("last-name");
        private static readonly By PostalCodeInputBy = By.Id("postal-code");
        private static readonly By ContinueButtonBy = By.Id("continue");              

        public CheckoutYourInformation(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutYourInformation(IWebDriver? driver) : base(driver, false)
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
                return Driver.FindElement(ContinueButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void SetFirstName(string firstName)
        {
            Driver.FindElement(FirstNameInputBy).SendKeys(firstName);
        }

        void SetLastName(string lastName)
        {
            Driver.FindElement(LastNameInputBy).SendKeys(lastName);
        }

        void SetPostalCode(string postalCode)
        {
            Driver.FindElement(PostalCodeInputBy).SendKeys(postalCode);
        }

        void ClickContinueButton()
        {
            Driver.FindElement(ContinueButtonBy).Click();
        }

        public CheckoutOverviewPage GetCheckoutOverview(User user)
        {
            SetFirstName(user.FirstName);
            SetLastName(user.LastName);
            SetPostalCode(user.UserCode);
            ClickContinueButton();
            return new CheckoutOverviewPage(Driver);
        }
    }
}
