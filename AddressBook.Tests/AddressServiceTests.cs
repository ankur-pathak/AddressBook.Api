using AddressBook.Api.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AddressBook.Tests
{
   public class AddressServiceTests
    {
        [Fact]
        public async Task DataFilePathFoundAndReadDataCorrectly_Test()
        {
            var hostingEnvironment = Mock.Of<IWebHostEnvironment>(e => e.ApplicationName == "Addressbook.Api" && e.ContentRootPath == "C:\\Users\\ankur\\source\\repos\\AddressBook.Api\\AddressBook.Api");
            var inMemorySettings = new Dictionary<string, string> { { "data", "/Data/sampleData.json" } };
         

            IConfiguration configuration = new ConfigurationBuilder()
                                            .AddInMemoryCollection(inMemorySettings)
                                            .Build();
            var repo = new AddressService(configuration, hostingEnvironment);

            var data = await repo.GetAddresses();
            var firstCity = data.ElementAt(0).city;
            Assert.Equal("London", firstCity);

        }
        [Fact]
        public async Task AddressGroupbyCorrectly_Test()
        {
            var hostingEnvironment = Mock.Of<IWebHostEnvironment>(e => e.ApplicationName == "Addressbook.Api" && e.ContentRootPath == "C:\\Users\\ankur\\source\\repos\\AddressBook.Api\\AddressBook.Api");
            var inMemorySettings = new Dictionary<string, string> { { "data", "/Data/sampleData.json" } };


            IConfiguration configuration = new ConfigurationBuilder()
                                            .AddInMemoryCollection(inMemorySettings)
                                            .Build();
            var repo = new AddressService(configuration, hostingEnvironment);

            var data = await repo.GetAddresses();
            var movedRecord = data.ElementAt(3).city;
            Assert.Equal("New York", movedRecord);

        }


    }
}
