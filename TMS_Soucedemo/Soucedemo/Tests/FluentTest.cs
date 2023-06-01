using Core.Models;
using System.Security.Cryptography.X509Certificates;
using TMS_Soucedemo.Soucedemo.BaseEntities;
using TMS_Soucedemo.Soucedemo.Pages;

namespace TMS_Soucedemo
{
    public class FluentTest : BaseTest
    {
        public LoginPage LoginPage { get; set; }
        public CheckoutCompletePage CheckoutCompletePage { get; set; }

        [SetUp]
        public void Setup()
        {
            LoginPage = new LoginPage(Driver);
            CheckoutCompletePage = new CheckoutCompletePage(Driver);
            LoginPage.OpenPage();
        }

        [Test]
        public void OrderTest()
        {
            string expectedSuccessMessage = "Thank you for your order!";

            User test_user = new UserBuilder()
                .SetUsername("standard_user")
                .SetPassword("secret_sauce")
                .SetFirstName("Ivan")
                .SetLastName("Petrov")
                .SetCode("246025")
                .Build();

            LoginPage.SuccessfulLogin(test_user)
                .GoToCartPage()
                .GoToCheckoutPage()
                .GetCheckoutOverview(test_user)
                .GoToCheckoutCompletePage();

            Assert.That(CheckoutCompletePage.GetSuccessMessage, Is.EqualTo(expectedSuccessMessage));
        }
    }
}