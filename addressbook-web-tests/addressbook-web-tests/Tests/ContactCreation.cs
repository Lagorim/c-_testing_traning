using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
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

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contact.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0])
                {
                    LastName = parts[1],
                    MiddleName = parts[2]
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contact.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contact.json"));
        }

        //[Test, TestCaseSource("RandomContactDataProvider")]
        //public void ContactCreationTest(ContactData contact)
        //{

        //    List<ContactData> oldContacts = application.Contacts.GetContactList();

        //    application.Contacts.Create(contact);

        //    Assert.AreEqual(oldContacts.Count +1, application.Contacts.GetContactCount());

        //    List <ContactData> newContacts = application.Contacts.GetContactList();
        //    oldContacts.Add(contact);
        //    oldContacts.Sort();
        //    newContacts.Sort();
        //    Assert.AreEqual(oldContacts, newContacts);
        //}

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest_new(ContactData contact)
        {

            List<ContactData> oldContacts = application.Contacts.GetContactList();

            application.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, application.Contacts.GetContactCount());

            List<ContactData> newContacts = application.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

