using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace AddressbookTest
{
    [TestFixture]
    public class ContactInformationTest : AuthBaseTest
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = application.Contacts.GetcontactInformationFromTable(0);
            ContactData fromForm = application.Contacts.GetContactInformationFromEdit(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromTable.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

            application.Contacts.GetNumberOfResults();
            Assert.NotNull(application.Contacts.GetNumberOfResults());
        }

    }
}
