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
            ContactData contactmodification = new ContactData("Alex");
            contactmodification.MiddleName = "Victorovich";
            contactmodification.LastName = "Moiseev";
            application.Contacts.Modification(contactmodification);
        }
    }
}
