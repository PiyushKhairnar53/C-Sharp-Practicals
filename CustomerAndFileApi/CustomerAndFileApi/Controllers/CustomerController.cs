using System;
using System.Net;
using CustomerAndFileApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAndFileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private static List<Customer> customerList = new List<Customer>()
        {
            new Customer() {Id = 1, Name = "ABC", Locations = new List<Locations>{new Locations(){custId = 1,Id = 1, City = "Pune", Address = "Bavdhan"} } },
        };

        /// <summary>
        /// Get all customer details.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            return customerList;
        }

        /// <summary>
        /// Get a customer by ID.
        /// </summary>
        /// <param name="id">Enter Id of Customer.</param>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the customer.", typeof(Customer))]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = customerList.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customer">Enter Customer</param>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            int newCustomerId = customerList.Max(c => c.Id) + 1;
            customer.Id = newCustomerId;
            customerList.Add(customer);
            return CreatedAtAction(nameof(customer.Id), new { id = customer.Id }, customer);
        }

        /// <summary>
        /// Update the customer
        /// </summary>
        /// <param name="id">Enter ID of customer to update.</param>
        /// <param name="newCustomer">Enter new details of customer</param>
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Customer successfully updated.")]
        public IActionResult Update(int id, Customer newCustomer)
        {
            var customer = customerList.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(newCustomer?.Name))
            {
                customer.Name = newCustomer.Name;
            }
            if (newCustomer?.Locations != null && newCustomer.Locations.Any())
            {
                customer.Locations = newCustomer.Locations;
            }

            return NoContent();
        }

        /// <summary>
        /// Delete the Customer by ID
        /// </summary>
        /// <param name="id">Enter Customer Id to delete.</param>
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Customer successfully deleted.")]
        public IActionResult Delete(int id)
        {
            var customer = customerList.FirstOrDefault(c => c.Id == id);

            if (customer.Locations != null && customer.Locations.Any())
            {
                return BadRequest("Cannot delete a customer which have locations");
            }

            customerList.Remove(customer);
            
            return NoContent();
        }

    }
}
