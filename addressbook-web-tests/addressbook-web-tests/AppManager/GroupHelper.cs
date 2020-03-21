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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Remove(GroupData group, int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectedGroup(group, v);
            DeleteGroup();
            ReturnToGroupPage();
            return this; 
        }

        public GroupHelper Modify(int v, GroupData modification, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectedGroup(group, v);
            InitGroupModification();
            FillGroupForm(modification);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SelectedGroup(GroupData group, int index)
        {
            if (IsSelected(index))
            {
                if (IsSelected())
                {
                    //driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
                }
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
                return this;
            }
            NewGroupCreate(group, index);            
            return this;
        }

        //Метод используется в тот момент, когда нужно создать группу для ее модификации или удаления, при этом сам список пуст

        public GroupHelper NewGroupCreate(GroupData group, int index)
        {
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public bool IsSelected()
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[]"));
        }

        public bool IsSelected(int index)
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]"));
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
