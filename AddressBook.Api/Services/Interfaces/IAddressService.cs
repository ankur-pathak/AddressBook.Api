using AddressBook.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Services.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAddresses();
        Task<IEnumerable<GroupedAddresses>> GetAddrerssGroups();
    }
}
