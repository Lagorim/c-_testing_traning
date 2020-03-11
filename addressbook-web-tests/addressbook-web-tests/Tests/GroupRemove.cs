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
            application.Groups.Remove(1);
            
        }        
    }
}
