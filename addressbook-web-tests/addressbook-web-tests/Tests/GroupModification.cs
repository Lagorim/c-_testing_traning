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
            GroupData modification = new GroupData("bbb");
            modification.Header = null;
            modification.Footer = null;
            application.Groups.Modify(1, modification);
        }
    }
}
