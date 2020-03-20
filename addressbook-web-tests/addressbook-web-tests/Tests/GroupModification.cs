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
            application.Groups.Modify(1, modification, group);
        }
    }
}
