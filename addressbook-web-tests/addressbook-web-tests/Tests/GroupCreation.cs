using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace AddressbookTest
{
    [TestFixture]
    public class GroupCreation : BaseTest
    {
        

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";
            application.Groups.Create(group);
            //application.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            application.Groups.Create(group);
            //application.Auth.Logout();
        }
    }
}
