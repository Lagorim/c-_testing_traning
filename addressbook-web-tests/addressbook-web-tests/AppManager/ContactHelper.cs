using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AddressbookTest
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base (manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.NewContactPage();
            CreationContact(contact);
            SubmitContact();
            manager.Navigator.NewContactPage();

            return this;
        }

        public ContactHelper Modification(ContactData contactmodification, ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            //ChoiceModificationContact(contact);
            EditPressButton();
            ModificationContact(contactmodification);
            SubmitModificationContact();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            //ChoiceModificationContact(contact);
            Remove();
            return this;
        }

        public ContactHelper ModificationContact(ContactData contactmodification)
        {
            Type(By.Name("firstname"), contactmodification.Name);
            Type(By.Name("middlename"), contactmodification.MiddleName);
            Type(By.Name("lastname"), contactmodification.LastName);
            return this;
        }

        public ContactHelper CreationContact(ContactData contact)
        {
            By locator = By.Name("theform");
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("middlename"), contact.MiddleName);
            TypeForContact(By.Name("theform"));
            Type(By.Name("lastname"), contact.LastName);
            TypeForContact(By.Name("theform"));
            return this;
        }

        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ReturnMainPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper SubmitModificationContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper EditPressButton()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public void InitModificationContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElement(By.XPath("//img[@alt='Edit']")).Click();
        }

        public ContactHelper ChoiceModificationContact(ContactData contact)
        {
            if (Selected())
                {
                //driver.FindElement(By.Name("selected[]")).Click();
                return this;
                }
            NewContactCreate(contact);            
            return this;
        }

        //Метод используется в тот момент, когда нужно создать контакт для его модификации или удаления, при этом сам список пуст
        public ContactHelper NewContactCreate(ContactData contact)
        {
            manager.Navigator.NewContactPage();
            CreationContact(contact);
            SubmitContact();
            manager.Navigator.OpenHomePage();
            //driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public bool Selected()
        {
            return IsElementPresent(By.XPath("//tr[@name='entry']"));
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper Remove()
        {
            contactCache = null;
            SelectContact();
            RemoveContact();
            //driver.FindElement(By.Name("selected[]")).Click();
            //driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                //ICollection<IWebElement> elements = driver.FindElements(By.Name("selected[]"));
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    
                    var firstName = element.FindElements(By.XPath("./td"))[2].Text;
                    var lastName = element.FindElements(By.XPath("./td"))[1].Text;

                    contactCache.Add(new ContactData(firstName, lastName)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }            
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactData GetcontactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
                //Email2 = email2,
                //Email3 = email3
            };
        }

        public ContactData GetContactInformationFromEdit(int index)
        {
            manager.Navigator.OpenHomePage();
            InitModificationContact(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3
            };
        }

        public int GetNumberOfResults()
        {
            manager.Navigator.OpenHomePage();
            return driver.FindElements(By.XPath("//span[@id='search_count']")).Count;
            //Match m = new Regex(@"\w+").Match(text);
            //return text;
                
        }
    }
}
