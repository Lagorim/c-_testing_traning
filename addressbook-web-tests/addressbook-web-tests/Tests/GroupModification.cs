using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookTest
{
    [TestFixture]
    public class GroupModification : AuthBaseTest
    {
        [Test]
        public void ModificationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "vvv";

            GroupData modification = new GroupData("ccc");
            modification.Header = null;
            modification.Footer = null;

            application.Groups.SelectedGroup(group, 1);
            application.Groups.Modify(1, modification, group);

            Assert.IsTrue(application.Groups.IsSelected(1));
        }

        [Test]
        public void CheckModificationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "vvv";

            GroupData modification = new GroupData("ccc");
            modification.Header = null;
            modification.Footer = null;

            //application.Groups.SelectedGroup(group, 1);
            List<GroupData> oldGroups = application.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            application.Groups.Modify(1, modification, group);

            Assert.AreEqual(oldGroups.Count, application.Groups.GetGroupCount());

            List<GroupData> newGroups = application.Groups.GetGroupList();
            //oldGroups.Add(group);
            oldGroups[0].Name = modification.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            //Assert.IsTrue(application.Groups.IsSelected(1));

            foreach (GroupData groups in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(modification.Name, group.Name);
                }
            }
        }
    }
}
