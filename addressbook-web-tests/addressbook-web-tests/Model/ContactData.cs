using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookTest
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        

        public ContactData(string name, string lastname)
        {
            Name = name;
            LastName = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name && LastName == other.LastName;            
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() & LastName.GetHashCode(); 
        }

        public override string ToString()
        {
            return "Firstname = " + Name + " " +LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name) & LastName.CompareTo(other.LastName);
        }

        public string Name { get; set; }
        

        public string MiddleName { get; set; }
        

        public string LastName { get; set; }

        public string Id { get; set; }
        
    }
}
