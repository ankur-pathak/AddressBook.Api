using AddressBook.Api.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Services
{
    public class AddressService : IAddressService
    {
        IConfiguration Configuration { get; }
        IWebHostEnvironment Environment { get; }
        public AddressService(IConfiguration config, IWebHostEnvironment env)
        {
            Configuration = config;
            Environment = env;
        }
       
        public async Task<IEnumerable<Address>> GetAddresses()
        {            
                using (var reader = new StreamReader(DataSourceFileName()))
                {
                    string json = await reader.ReadToEndAsync();                     
                   return JsonConvert.DeserializeObject<IEnumerable<Address>>(json).
                            GroupBy(a => a.city, StringComparer.CurrentCultureIgnoreCase).
                            SelectMany(group => group);              
                }            
        }
        private string DataSourceFileName()
        {
            return    Environment.ContentRootPath + "/"+ Configuration["data"];
        }
    }
}
