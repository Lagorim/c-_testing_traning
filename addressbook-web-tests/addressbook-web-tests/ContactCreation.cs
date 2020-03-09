using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace AddressbookTest
{
    [TestFixture]
    public class ContactCreation : BaseTest
    {
        

        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            NewContactPage();
            ContactData contact = new ContactData("igor");
            contact.MiddleName = "Victor";
            contact.LastName = "Pronin";
            CreationContact(contact);
            SubmitContact();
            ReturnMainPage();
            Logout();
        }
    }
}

