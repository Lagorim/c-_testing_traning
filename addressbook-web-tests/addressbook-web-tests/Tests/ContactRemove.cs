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
            ContactData contact = new ContactData("igor");
            contact.MiddleName = "Victor";
            contact.LastName = "Pronin";

            application.Contacts.ChoiceModificationContact(contact);
            application.Contacts.Remove(contact);
            application.CloseDialogWindow();

            Assert.IsFalse(application.Contacts.Selected());
        }

        [Test]
        public void CheckContactAfterDeletion()
        {
            ContactData contact = new ContactData("igor");
            contact.MiddleName = "Victor";
            contact.LastName = "Pronin";

            application.Contacts.ChoiceModificationContact(contact);
            application.Contacts.Remove(contact);
            application.CloseDialogWindow();

            Assert.IsTrue(application.Contacts.Selected());
        }

    }
}
