using System;
using System.Net;
using CustomerAndFileApi.Models;
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
        /// Gets all customers.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        [HttpGet]


        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            return customerList;
        }

        /// <summary>
        /// Gets a customer by ID.
        /// </summary>
        /// <param name="id">Enter Id of Customer.</param>
        /// <returns>The customer object.</returns>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the customer.", typeof(Customer))]
        public ActionResult<Customer> GetById(int id)
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
        /// <param name="customer">Create customer</param>
        /// <returns>The created customer object.</returns>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            // assign new id to customer
            int newCustomerId = customerList.Max(c => c.Id) + 1;
            customer.Id = newCustomerId;

            customerList.Add(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="id">The ID of the customer to update.</param>
        /// <param name="updatedCustomer">The updated customer object.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Customer successfully updated.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid customer ID or missing fields.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Customer not found.")]
        public IActionResult Update(int id, Customer updatedCustomer)
        {
            var customer = customerList.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            //update fields from updated customer
            if (!string.IsNullOrEmpty(updatedCustomer?.Name))
            {
                customer.Name = updatedCustomer.Name;
            }
            if (updatedCustomer?.Locations != null && updatedCustomer.Locations.Any())
            {
                customer.Locations = updatedCustomer.Locations;
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Customer successfully deleted.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Customer not found.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Cannot delete a customer with associated locations.")]
        public IActionResult Delete(int id)
        {
            var customer = customerList.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            if (customer.Locations != null && customer.Locations.Any())
            {
                return BadRequest("Cannot delete a customer with associated locations");
            }

            customerList.Remove(customer);

            return NoContent();
        }


    }
}
