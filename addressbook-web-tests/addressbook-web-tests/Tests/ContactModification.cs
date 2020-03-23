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
            ContactData contact = new ContactData("igor");
            contact.MiddleName = "Victor";
            contact.LastName = "Pronin";

            ContactData contactmodification = new ContactData("Alex");
            contactmodification.MiddleName = "Victorovich";
            contactmodification.LastName = "Moiseev";

            application.Contacts.ChoiceModificationContact(contact);
            application.Contacts.Modification(contactmodification, contact);

            Assert.IsTrue(application.Contacts.Selected());
        }
    }
}
