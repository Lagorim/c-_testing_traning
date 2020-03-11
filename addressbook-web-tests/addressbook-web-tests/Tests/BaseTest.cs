using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace AddressbookTest
{
    public class BaseTest
    {
        protected ApplicationManager application;

        [SetUp]
        public void SetupTest()
        {
            application = new ApplicationManager();
            application.Navigator.OpenHomePage();
            application.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            application.Auth.Logout();
            application.Stop();          
        }   
    }
}
