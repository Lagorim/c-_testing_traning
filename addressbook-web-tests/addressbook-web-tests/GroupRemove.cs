using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace AddressbookTest
{
    [TestFixture]
    public class RemoveGroup : BaseTest
    {
        

        [Test]
        public void RemoveGroupTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectedGroup(1);
            DeleteGroup();
            ReturnToGroupPage();
        }        
    }
}
