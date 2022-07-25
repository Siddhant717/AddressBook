using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProblems
{
    public class AddressBookModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public int AddressBookId { get; set; }
        public string Type { get; set; }

        public DateTime Date_Added { get; set; }

    }
}
