using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using AddressbookTest;
using Newtonsoft.Json;

namespace address_book_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            List<ContactData> contacts = new List<ContactData>();
            List<GroupData> groups = new List<GroupData>();
            if (count == 2)
            {
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(BaseTest.GeneraterandomString(10))
                    {
                        LastName = BaseTest.GeneraterandomString(10),
                        MiddleName = BaseTest.GeneraterandomString(10)
                    });
                }
                if (format == "csv")
                {
                    writeContactToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Error format" + format);
                }
                writer.Close();
            }
            else
            {
                {
                    for (int i = 0; i < count; i++)
                    {
                        groups.Add(new GroupData(BaseTest.GeneraterandomString(10))
                        {
                            Header = BaseTest.GeneraterandomString(10),
                            Footer = BaseTest.GeneraterandomString(10)
                        });
                    }
                    if (format == "csv")
                    {
                        writeGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        writeGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        writeGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Error format" + format);
                    }
                    writer.Close();
                }
            }           
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0}, ${1}, ${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0}, ${1}, ${2}",
                    contact.Name, contact.LastName, contact.MiddleName));
            }
        }

        static void writeContactToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
