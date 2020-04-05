using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookTest
{
    [TestFixture]
    public class ContactModification : AuthBaseTest
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("igor", "pro");
            contact.MiddleName = "Victor";
            //contact.LastName = "Pronin";

            ContactData contactmodification = new ContactData("Alex", "po");
            contactmodification.MiddleName = "Victorovich";
            //contactmodification.LastName = "Moiseev";

            application.Contacts.ChoiceModificationContact(contact);
            application.Contacts.Modification(contactmodification, contact);

            Assert.IsTrue(application.Contacts.Selected());
        }

        [Test]
        public void SortModificationTest()
        {
            ContactData contact = new ContactData("igor", "pro");
            contact.MiddleName = "Victor";
            //contact.LastName = "Pronin";

            ContactData contactmodification = new ContactData("Alex", "po");
            contactmodification.MiddleName = "Victorovich";
            //contactmodification.LastName = "Moiseev";



            List<ContactData> oldContacts = application.Contacts.GetcontactList();

            application.Contacts.ChoiceModificationContact(contact);
            application.Contacts.Modification(contactmodification, contact);

            List<ContactData> newContacts = application.Contacts.GetcontactList();
            oldContacts[0].Name = contactmodification.Name;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
