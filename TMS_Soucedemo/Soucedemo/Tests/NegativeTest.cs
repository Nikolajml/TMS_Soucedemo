using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Soucedemo.Soucedemo.BaseEntities;
using TMS_Soucedemo.Soucedemo.Pages;

namespace TMS_Soucedemo.Soucedemo.Tests
{
    public class NegativeTest : BaseTest
    {
        [Test]
        public void UnsuccessfulLoginTest()
        {
            string expectedErroreMessage = "Epic sadface: Username and password do not match any user in this service";

            User error_user = new UserBuilder()
                .SetUsername("standard_user")
                .SetPassword("incorrect_password")
                .Build();

            LoginPage.LoginWithIncorrectPassword(error_user);

            Assert.That(LoginPage.GetErrorMessage, Is.EqualTo(expectedErroreMessage));
        }
    }
}
