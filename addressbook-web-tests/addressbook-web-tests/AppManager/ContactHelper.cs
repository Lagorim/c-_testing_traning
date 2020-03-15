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

        public ContactHelper Remove()
        {
            ReturnMainPage();
            ChoiceModificationContact();
            EditPressButton();
            RemoveContact();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.NewContactPage();
            CreationContact(contact);
            SubmitContact();
            ReturnMainPage();
            
            return this;
        }



        public ContactHelper Modification(ContactData contactmodification)
        {
            ReturnMainPage();
            ChoiceModificationContact();
            EditPressButton();
            ModificationContact(contactmodification);
            SubmitModificationContact();
            ReturnMainPage();
            return this;
        }

        public ContactHelper ModificationContact(ContactData contactmodification)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contactmodification.Name);            
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contactmodification.MiddleName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contactmodification.LastName);
            return this;
        }

        public ContactHelper CreationContact(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Name);
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            driver.FindElement(By.Name("theform")).Click();
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

        public ContactHelper ChoiceModificationContact()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }
    }
}
