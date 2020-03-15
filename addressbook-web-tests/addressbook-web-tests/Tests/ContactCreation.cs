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
            ContactData contact = new ContactData("igor");
            contact.MiddleName = "Victor";
            contact.LastName = "Pronin";
            application.Contacts.Create(contact);
        }
    }
}

