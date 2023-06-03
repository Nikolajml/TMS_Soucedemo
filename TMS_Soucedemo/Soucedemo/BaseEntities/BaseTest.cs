using Core.Utilites.Configuration;
using Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Soucedemo.Soucedemo.Pages;
using NUnit.Allure.Core;
using Allure.Commons;

namespace TMS_Soucedemo.Soucedemo.BaseEntities
{
    [AllureNUnit]
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected static IWebDriver? Driver;
        protected WaitService? WaitService;
        public LoginPage LoginPage { get; set; }
        public CheckoutCompletePage CheckoutCompletePage { get; set; }
        
        private AllureLifecycle _allure;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //Initialization allure
            _allure = AllureLifecycle.Instance;
        }

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);

            LoginPage = new LoginPage(Driver);
            CheckoutCompletePage = new CheckoutCompletePage(Driver);
            LoginPage.OpenPage();
        }

        [TearDown]
        public void TearDown()
        {
            //Проверка, что тест упал
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                //Создать скриншот
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                //Приклепление скриншота
                _allure.AddAttachment(name: "Screenshot", type: "image/png", screenshotBytes);
            }
            Driver?.Quit();
        }
    }
}
