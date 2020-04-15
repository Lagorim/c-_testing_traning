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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GeneraterandomString(20), GeneraterandomString(30))
                {
                    LastName = GeneraterandomString(50),
                    MiddleName = GeneraterandomString(50)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {

            List<ContactData> oldContacts = application.Contacts.GetContactList();

            application.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count +1, application.Contacts.GetContactCount());

            List <ContactData> newContacts = application.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

