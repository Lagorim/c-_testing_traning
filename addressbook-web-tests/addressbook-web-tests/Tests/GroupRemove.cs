using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace AddressbookTest
{
    [TestFixture]
    public class RemoveGroup : AuthBaseTest
    {
        

        [Test]
        public void RemoveGroupTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "vvv";

            application.Groups.SelectedGroup(group, 1);
            application.Groups.Remove(group, 1);

            Assert.IsFalse(application.Groups.IsSelected());            
        }

        [Test]
        public void CheckGroupAfterDeletion()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "vvv";

            application.Groups.SelectedGroup(group, 1);
            application.Groups.Remove(group, 1);

            Assert.IsTrue(application.Groups.IsSelected(1));
        }

        [Test]
        public void CheckGroupCountDeletion()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "vvv";

            //application.Groups.SelectedGroup(group, 1);
            List<GroupData> oldGroups = application.Groups.GetGroupList();
            application.Groups.Remove(group, 1);
            List<GroupData> newGroups = application.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
