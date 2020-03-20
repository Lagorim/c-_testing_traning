using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


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

            application.Groups.Remove(group, 1);
            
        }        
    }
}
