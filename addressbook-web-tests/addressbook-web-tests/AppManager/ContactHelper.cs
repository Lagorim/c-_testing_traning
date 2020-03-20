using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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
            ChoiceModificationContact(contact);
            EditPressButton();
            ModificationContact(contactmodification);
            SubmitModificationContact();
            manager.Navigator.OpenHomePage();
            return this;
        }
        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            ChoiceModificationContact(contact);
            RemoveContact();
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
            return this;
        }

        public ContactHelper EditPressButton()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper ChoiceModificationContact(ContactData contact)
        {
            if (Selected())
                {
                driver.FindElement(By.Name("selected[]")).Click();
                return this;
                }
            manager.Navigator.NewContactPage();
            CreationContact(contact);
            SubmitContact();
            manager.Navigator.OpenHomePage();
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        private bool Selected()
        {
            return IsElementPresent(By.XPath("//tr[@name='entry']"));
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
    }
}
