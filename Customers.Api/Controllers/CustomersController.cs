using System;
using System.Threading.Tasks;
using Customers.Infrastructure.Commands;
using Customers.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Api.Controllers {
    [Route ("api/[controller]")]
    public class CustomersController : Controller {
        private readonly ICustomerService _customerService;

        public CustomersController (ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetCustomer (int id) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            return Json (await _customerService.GetAsync (id));
        }

        [HttpGet ("search")]
        public async Task<IActionResult> BrowseCustomers ([FromQuery] string query) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            return Json (await _customerService.BrowseAsync (query));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer ([FromBody] CreateCustomer command) {
            if (await _customerService.ExistByPhoneNumberAsync (command.TelephoneNumber))
                ModelState.AddModelError ("PhoneNumber", "Phone number is already taken.");
            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            await _customerService.CreateAsync (command.Name, command.Surname, command.TelephoneNumber, command.FlatNumber, command.BuildingNumber, command.Street, command.City, command.ZipCode);
            return StatusCode (201);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateCustomer (int id, [FromBody] CreateCustomer command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            await _customerService.UpdateAsync (id, command.Name, command.Surname, command.TelephoneNumber, command.FlatNumber, command.BuildingNumber, command.Street, command.City, command.ZipCode);
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteCustomer (int id) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            await _customerService.DeleteAsync (id);
            return NoContent ();
        }
    }
}