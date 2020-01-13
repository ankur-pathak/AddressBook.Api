using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public class GroupedAddresses
    {
        public string City { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
