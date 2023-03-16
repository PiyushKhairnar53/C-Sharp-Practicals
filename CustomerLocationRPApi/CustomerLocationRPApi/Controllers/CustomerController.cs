using CustomerLocationRPApi.Services.Models;
using CustomerLocationRPApi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerLocationRPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _ICustomerRespository;
        private readonly ICustomerLocationRepository _ICustomerLocationRepository;

        public CustomerController(ICustomerRepository iCustomerRepository, ICustomerLocationRepository iCustomerLocationRepository)
        {
            _ICustomerRespository = iCustomerRepository;
            _ICustomerLocationRepository = iCustomerLocationRepository;
        }

        /// <summary>
        /// Get all customer details.
        /// </summary>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all customers", typeof(Customer))]
        public IActionResult GetAllCustomers()
        {
            return Ok(_ICustomerRespository.GetAllCustomers());
        }

        /// <summary>
        /// Get a customer by ID.
        /// </summary>
        /// <param name="id">Enter Id of Customer.</param>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the customer.", typeof(Customer))]
        public IActionResult GetCustomerById(int id)
        {
            Customer customer = _ICustomerRespository.GetCustomerById(id);
            if (customer != null)
                return Ok(customer);
            else
                return BadRequest("You have entered wrong credentials");
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customer">Enter Customer</param>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Customer successfully added.")]
        public IActionResult AddCustomerDetails(Customer customer)
        {
            if (customer != null)
            {
                return Ok(_ICustomerRespository.AddCustomerDetails(customer));
            }
            return BadRequest("You have entered wrong credentials");
        }

        /// <summary>
        /// Update the customer
        /// </summary>
        /// <param name="id">Enter ID of customer to update.</param>
        /// <param name="newCustomer">Enter new details of customer</param>
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Customer not found.", typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status200OK, "Customer successfully updated.")]
        public IActionResult UpdateCustomerDetails(int id, Customer newCustomer)
        {
            Customer customer = _ICustomerRespository.UpdateCustomerDetails(id, newCustomer);
            if (!string.IsNullOrEmpty(newCustomer?.Name))
            {
                return Ok(customer);
            }
            return BadRequest("You have entered wrong credentials");
        }

        /// <summary>
        /// Delete the Customer by ID
        /// </summary>
        /// <param name="id">Enter Customer Id to delete.</param>
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Customer not found.", typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Customer successfully deleted.")]
        public IActionResult DeleteCustomerDetails(int id)
        {
            Customer customer = _ICustomerRespository.DeleteCustomerDetails(id);
            if (customer.Locations != null && customer.Locations.Any())
            {
                return BadRequest("Cannot delete a customer which have locations");
            }
            return Ok(customer);
        }

        /// <summary>
        /// Add the Location of Customer
        /// </summary>
        /// <param name="id">Enter Customer Id.</param>      
        /// <param name="newLocation">Enter Location details</param>        
        [Route("Location")]
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Location not found.", typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status200OK, "Location successfully added.")]
        public IActionResult AddCustomerLocation(int id, Locations newLocation)
        {
            Locations locations = _ICustomerLocationRepository.AddCustomerLocation(id, newLocation);
            if (locations != null)
            {
                return Ok(locations);
            }
            return BadRequest("Customer not found");
        }

        /// <summary>
        /// Update the Location of Customer
        /// </summary>
        /// <param name="id">Enter Customer Id.</param>      
        /// <param name="locationId">Enter Location Id to Update Location.</param>   
        /// <param name="location">Enter Location details.</param>  
        [Route("Location")]
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Location not found.", typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status200OK, "Location successfully updated.")]
        public IActionResult UpdateCustomerLocation(int id, int locationId, Locations location)
        {

            Locations locations = _ICustomerLocationRepository.UpdateCustomerLocations(id, locationId, location);
            if (locations != null)
            {
                return Ok(locations);
            }
            return BadRequest("You have entered wrong credentials");
        }

        /// <summary>
        /// Get the Location of Customer
        /// </summary>
        /// <param name="id">Enter Customer Id.</param>      
        /// <param name="locationId">Enter Location Id to Get Location.</param>
        [Route("Location")]
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Location not found.", typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status200OK, "Location successfully found.")]
        public IActionResult GetCustomerLocationById(int id, int locationId)
        {
            Locations locations = _ICustomerLocationRepository.GetCustomerLocationById(id, locationId);
            if (locations != null)
            {
                return Ok(locations);
            }
            return BadRequest("Cannot fetch,You have entered wrong credentials");
        }

        /// <summary>
        /// Delete the Location of Customer
        /// </summary>
        /// <param name="id">Enter Customer Id.</param>
        /// <param name="locationId">Enter Location Id to delete Location.</param>
        [Route("Location")]
        [HttpDelete]
        [SwaggerResponse(StatusCodes.Status200OK, "Location Deleted.", typeof(Locations))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Location not found.", typeof(Locations))]
        public IActionResult DeleteCustomerLocation(int id, int locationId)
        {
            Locations locations = _ICustomerLocationRepository.DeleteCustomerLocation(id, locationId);
            if (locations != null)
            {
                return Ok(locations);
            }
            return BadRequest("Cannot delete,You have entered wrong credentials");
        }
    }
}
