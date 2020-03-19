using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookTest
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //подготовка
            application.Auth.Logout();

            //действие
            AccountData account = new AccountData("admin", "secret");
            application.Auth.Login(account);

            //проверка
            Assert.IsTrue(application.Auth.IsLoggedIn());
        }

        [Test]
        public void LoginWithNotValidCredentials()
        {
            //подготовка
            application.Auth.Logout();

            //действие
            AccountData account = new AccountData("admin", "12345");
            application.Auth.Login(account);

            //проверка
            Assert.IsFalse(application.Auth.IsLoggedIn());
        }
    }
}
