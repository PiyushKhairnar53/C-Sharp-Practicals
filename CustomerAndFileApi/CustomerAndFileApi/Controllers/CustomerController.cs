using System;
using System.Net;
using System.Xml.Linq;
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
            new Customer() {Id = 1, Name = "ABC", Locations = new List<Locations>{new Locations(){Id = 1, City = "Pune", Address = "Bavdhan"} } },
        };

        /// <summary>
        /// Get all customer details.
        /// </summary>
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            if (customerList != null)
            {
                return Ok(customerList);
            }
            
            return NoContent();
        }

        /// <summary>
        /// Get a customer by ID.
        /// </summary>
        /// <param name="id">Enter Id of Customer.</param>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the customer.", typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Customer not found.", typeof(Customer))]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                var customer = customerList.FirstOrDefault(c => c.Id == id);
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception exception) 
            {
                return BadRequest(exception.Message);
            }
            
            return NoContent();
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customer">Enter Customer</param>
        [HttpPost]
        public IActionResult AddCustomerDetails(Customer customer)
        {
            int newCustomerId = customerList.Max(c => c.Id) + 1;
            customer.Id = newCustomerId;
            try
            {
                customerList.Add(customer);
                return CreatedAtAction(nameof(customer.Id), new { id = customer.Id }, customer);
            }
            catch (Exception exception) 
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Update the customer
        /// </summary>
        /// <param name="id">Enter ID of customer to update.</param>
        /// <param name="newCustomer">Enter new details of customer</param>
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Customer not found.", typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Customer successfully updated.")]
        public IActionResult UpdateCustomerDetails(int id, Customer newCustomer)
        {
            var customer = customerList.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(newCustomer?.Name))
            {
                customer.Name = newCustomer.Name;
                return Ok();
            }
            if (newCustomer?.Locations != null && newCustomer.Locations.Any())
            {
                customer.Locations = newCustomer.Locations;
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        /// Delete the Customer by ID
        /// </summary>
        /// <param name="id">Enter Customer Id to delete.</param>
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Customer not found.", typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Customer successfully deleted.")]
        public IActionResult DeleteCustomerDeatils(int id)
        {
            var customer = customerList.FirstOrDefault(c => c.Id == id);

            if (customer.Locations != null && customer.Locations.Any())
            {
                return BadRequest("Cannot delete a customer which have locations");
            }
            try
            {
                if (customerList.Contains(customer))
                {
                    customerList.Remove(customer);
                    return Ok(customer);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception exception) 
            {
                return BadRequest(exception.Message);
            }
            return NoContent();
        }

        /// <summary>
        /// Delete the Location of Customer
        /// </summary>
        /// <param name="id">Enter Customer Id.</param>
        /// <param name="locationId">Enter Location Id to delete Location.</param>
        [Route("location")]
        [HttpDelete]
        [SwaggerResponse(StatusCodes.Status200OK, "Location Deleted.", typeof(Locations))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Location not found.", typeof(Locations))]
        public IActionResult DeleteCustomerLocation(int id,int locationId)
        {
            foreach (Customer customer in customerList) 
            {
                if (customer.Id == id) 
                {
                    List<Locations> oldCustomerLocations = new List<Locations>();

                    foreach (Locations location in customer.Locations) 
                    {
                        oldCustomerLocations.Add(location);
                    }
                    try
                    {
                        var itemToRemove = oldCustomerLocations.Single(r => r.Id == locationId);
                        if (oldCustomerLocations.Contains(itemToRemove))
                        {
                            oldCustomerLocations.Remove(itemToRemove);
                            customer.Locations = oldCustomerLocations;
                            return Ok(itemToRemove);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    catch(Exception ex) 
                    {
                        return BadRequest("Exception:"+ex.Message);
                    }
                }
            }
            return NoContent();
        }

    }
}
