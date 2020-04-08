using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace AddressbookTest
{
    [TestFixture]
    public class GroupCreation : AuthBaseTest
    {
        

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";

            List<GroupData> oldGroups = application.Groups.GetGroupList();
            
            application.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, application.Groups.GetGroupCount());

            List<GroupData> newGroups = application.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = application.Groups.GetGroupList();

            application.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, application.Groups.GetGroupCount());

            List<GroupData> newGroups = application.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = application.Groups.GetGroupList();

            application.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, application.Groups.GetGroupCount());

            List<GroupData> newGroups = application.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
