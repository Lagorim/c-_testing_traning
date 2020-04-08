using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookTest
{
    [TestFixture]
    public class ContactRemove : AuthBaseTest
    {
        [Test]
        public void RemoveContact()
        {
            ContactData contact = new ContactData("igor", "igor");
            contact.MiddleName = "Victor";
            //contact.LastName = "Pronin";

            

            application.Contacts.ChoiceModificationContact(contact);
            application.Contacts.Remove(contact);
            application.CloseDialogWindow();

            Assert.IsFalse(application.Contacts.Selected());
        }

        [Test]
        public void CheckContactAfterDeletion()
        {
            ContactData contact = new ContactData("igor", "io");
            contact.MiddleName = "Victor";
            //contact.LastName = "Pronin";



            application.Contacts.ChoiceModificationContact(contact);
            application.Contacts.Remove(contact);
            application.CloseDialogWindow();

            Assert.IsTrue(application.Contacts.Selected());
        }

        [Test]
        public void CheckCoolectionDelete()
        {
            ContactData contact = new ContactData("igor", "io");
            contact.MiddleName = "Victor";

            List<ContactData> oldContacts = application.Contacts.GetContactList();
            application.Contacts.Remove(contact);
            application.CloseDialogWindow();

            List<ContactData> newcontacts = application.Contacts.GetContactList();

            Assert.AreEqual(oldContacts.Count - 1, newcontacts.Count);

            List<ContactData> newContacts = application.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contacts in newContacts)
            {
                Assert.AreNotEqual(contacts.Id, toBeRemoved.Id);
            }

        }

        [Test]
        public void Delete()
        {
            List<ContactData> oldContacts = application.Contacts.GetContactList();
            application.Contacts.Remove();
            application.CloseDialogWindow();

            List<ContactData> newcontacts = application.Contacts.GetContactList();

            Assert.AreEqual(oldContacts.Count - 1, newcontacts.Count);

            List<ContactData> newContacts = application.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contacts in newContacts)
            {
                Assert.AreNotEqual(contacts.Id, toBeRemoved.Id);
            }

        }
    }
}
