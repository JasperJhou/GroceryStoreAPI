using GroceryStoreAPI.Abstract;
using GroceryStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomers")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("GetCustomerById/{id=id}")]
        public ActionResult<Customer> GetCustomerById([FromQuery] int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("AddCustomer")]
        public ActionResult AddCustomer([FromBody] Customer customer)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _customerService.AddCustomer(customer);
            return CreatedAtAction("AddCustomer", result);
            
        }

        [HttpPut("UpdateCustomerById")]
        public ActionResult UpdateCustomerById([FromBody] Customer customer)
        {
            var result = _customerService.UpdateCustomerById(customer);
            if(result != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
