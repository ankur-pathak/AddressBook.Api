using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
         private IAddressService AddressService { get; }
        public AddressesController(IAddressService addressService)
        {
            AddressService = addressService;
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Addresses()
        {
            try
            {
                var results = await AddressService.GetAddresses();
                return Ok(results);
            }
            catch (Exception ex){
                return StatusCode(500, ex.Message);

            }
        }

        [Route("Groups")]
        [HttpGet]
        public async Task<IActionResult> AddressGroups()
        {
            try
            {
                var results = await AddressService.GetAddrerssGroups();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

    }
}