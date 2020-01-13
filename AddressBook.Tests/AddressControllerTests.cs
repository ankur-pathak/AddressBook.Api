using AddressBook.Api;
using AddressBook.Api.Controllers;
using AddressBook.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AddressBook.Tests
{
  public  class AddressControllerTests
    {
        private readonly Mock<IAddressService> _mockRepo;
       
        public AddressControllerTests()
        {
            _mockRepo = new Mock<IAddressService>();
        }

        [Fact]
        public async  Task  GetsAddressReturnsCorrectValues_Test()
        {
              var addresses = new List<Address> { new Address() { firstname = "a", city = "London"}, new Address {city = "New york", firstname = "b" } };
             _mockRepo.Setup(repo => repo.GetAddresses())
             .ReturnsAsync(addresses);

            var _controller = new AddressesController(_mockRepo.Object);
            var result = await _controller.Addresses();

            var vr = Assert.IsType<OkObjectResult>(result);
            var addreadResults = Assert.IsAssignableFrom<IEnumerable<Address>>(vr.Value);
            Assert.Equal(2, addreadResults.Count());            
        }
    }
}
