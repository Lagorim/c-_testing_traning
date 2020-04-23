using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;
using NUnit.Framework;


namespace AddressbookTest
{
    [TestFixture]
    public class GroupCreation : AuthBaseTest
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GeneraterandomString(30))
                {
                    Header = GeneraterandomString(100),
                    Footer = GeneraterandomString(100)
                });
            }
            return groups;
        }


        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string [] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        //[Test, TestCaseSource("RandomGroupDataProvider")]
        //public void GroupCreationTest(GroupData group)
        //{

        //    List<GroupData> oldGroups = application.Groups.GetGroupList();

        //    application.Groups.Create(group);

        //    Assert.AreEqual(oldGroups.Count + 1, application.Groups.GetGroupCount());

        //    List<GroupData> newGroups = application.Groups.GetGroupList();
        //    oldGroups.Add(group);
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups);
        //}

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest_new(GroupData group)
        {

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
