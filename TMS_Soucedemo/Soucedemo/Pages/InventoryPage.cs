using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Soucedemo.Soucedemo.BaseEntities;

namespace TMS_Soucedemo.Soucedemo.Pages
{
    public class InventoryPage : BasePage
    {
        private static string END_POINT = "inventory.html";

        private static readonly By AddToCartTShirtButtonBy = By.Id("add-to-cart-sauce-labs-bolt-t-shirt");
        private static readonly By SauceLabsOnesieImageBy = By.Id("item_2_img_link");
        private static readonly By ShoppingCartIconBy = By.ClassName("shopping_cart_link");

        public InventoryPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public InventoryPage(IWebDriver? driver) : base(driver, false)
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
                return Driver.FindElement(SauceLabsOnesieImageBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void AddToCartClickButton()
        {
            Driver.FindElement(AddToCartTShirtButtonBy).Click();
        }

        void GoToCartClickButton()
        {
            Driver.FindElement(ShoppingCartIconBy).Click();
        }

        public CartPage GoToCartPage()
        {
            AddToCartClickButton();
            GoToCartClickButton();
            return new CartPage(Driver);
        }
    }
}
