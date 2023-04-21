using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ReactCustomerLocationApi.Models;
using ReactCustomerLocationApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ReactCustomerLocationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLocationService _ICustomerLocationService;

        public CustomerController(ICustomerLocationService customerLocationService)
        {
            _ICustomerLocationService = customerLocationService;
        }

        [HttpGet]
         public IActionResult GetAllCustomers()
        {
            return Ok(_ICustomerLocationService.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            Customer customer = _ICustomerLocationService.GetCustomerById(id);
            if (customer != null)
                return Ok(customer);
            else
                return BadRequest("You have entered wrong credentials");
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            customer.CustomerId = 0;
            if (!string.IsNullOrEmpty(customer.Name) && customer.Age > 18 && !string.IsNullOrEmpty(customer.ContactNo))
            {
                return Ok(_ICustomerLocationService.AddCustomer(customer));
            }
            return BadRequest("You have entered wrong credentials");
        }

        [HttpPut("{id}")]       
         public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if ( id > 0  && !string.IsNullOrEmpty(customer.Name) && customer.Age > 18 && !string.IsNullOrEmpty(customer.ContactNo))
            {
                return Ok(_ICustomerLocationService.UpdateCustomer(id,customer));
            }
            return BadRequest("You have entered wrong credentials");
        }

        [HttpDelete("{id}")]
       public IActionResult DeleteCustomer(int id)
        {
            if (id > 0)
            {
                Customer customer = _ICustomerLocationService.DeleteCustomer(id);
                if (customer != null)
                {
                    return Ok(customer);
                }
                return BadRequest("Customer have location");
            }
            return BadRequest("Wrong Customer ID enetered");
        }
    }
}
