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

        [HttpPost ()]
        public async Task<IActionResult> CreateCustomer ([FromBody] CreateCustomer command) {
            if (await _customerService.ExistByPhoneNumberAsync (command.TelephoneNumber))
                ModelState.AddModelError ("PhoneNumber", "Phone number is already taken.");
            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            try {
                await _customerService.CreateAsync (command.Name, command.Surname, command.TelephoneNumber, command.FlatNumber, command.BuildingNumber, command.Street, command.City, command.ZipCode);
                return StatusCode (201);
            } catch {
                return BadRequest ("Something went wrong");
            }
            // catch  {
            // return BadRequest (new { message = e.Message });
            // }
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateCustomer (int id, [FromBody] CreateCustomer command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _customerService.UpdateAsync (id, command.Name, command.Surname, command.TelephoneNumber, command.FlatNumber, command.BuildingNumber, command.Street, command.City, command.ZipCode);
                return NoContent ();
            } catch {
                // return BadRequest (new { message = e.Message });
                return BadRequest ("Something went wrong");
            }
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteCustomer (int id) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _customerService.DeleteAsync (id);
                return NoContent ();
            } catch {
                // return BadRequest (new { message = e.Message });
                return BadRequest ("Something went wrong");
            }
        }
    }
}