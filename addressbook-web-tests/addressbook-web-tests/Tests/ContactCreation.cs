using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace AddressbookTest
{
    [TestFixture]
    public class ContactCreation : AuthBaseTest
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("igor", "pronin");
            contact.MiddleName = "Victor";
            //contact.LastName = "Pronin";

            List<ContactData> oldContacts = application.Contacts.GetcontactList();

            application.Contacts.Create(contact);

            List <ContactData> newContacts = application.Contacts.GetcontactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

