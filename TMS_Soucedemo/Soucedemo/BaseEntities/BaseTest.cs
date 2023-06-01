using Core.Utilites.Configuration;
using Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Soucedemo.Soucedemo.BaseEntities
{
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected static IWebDriver? Driver;
        protected WaitService? WaitService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
        }
    }
}
