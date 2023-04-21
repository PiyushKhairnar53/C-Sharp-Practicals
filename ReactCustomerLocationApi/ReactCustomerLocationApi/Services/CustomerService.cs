using Microsoft.IdentityModel.Tokens;
using ReactCustomerLocationApi.Data;
using ReactCustomerLocationApi.Models;

namespace ReactCustomerLocationApi.Services
{
    public interface ICustomerLocationService
    {
        public Customer AddCustomer(Customer customer);
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetCustomerById(int customerId);
        public Customer UpdateCustomer(int id, Customer customer);
        public Customer DeleteCustomer(int customerId);
    }

    public class CustomerService : ICustomerLocationService
    {

        private CustomerLocationDBContext customerLocationDBContext;
        public CustomerService(CustomerLocationDBContext _context)
        {
            customerLocationDBContext = _context;
        }

        public Customer AddCustomer(Customer customer)
        {
            try
            {
                customerLocationDBContext.Customers.Add(customer);
                customerLocationDBContext.SaveChanges();
                return customer;
            }
            catch (Exception exception)
            {
                return null!;
            }
        }

        public Customer DeleteCustomer(int customerId)
        {      
            Customer customer = customerLocationDBContext.Customers.FirstOrDefault(s => s.CustomerId == customerId);

            if (customer != null)
            {
                if (IsAddressEmpty(customer.Street, customer.City, customer.Zipcode, customer.State, customer.Country) == true)
                {
                    customerLocationDBContext.Customers.Remove(customer);
                    customerLocationDBContext.SaveChanges();
                    return customer;
                }
            }
            return null;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customerLocationDBContext.Customers!.ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = customerLocationDBContext.Customers.FirstOrDefault(s => s.CustomerId == customerId);
            if (customer != null) 
            {
                return customer;
            }
            return null;
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            Customer findCustomer = customerLocationDBContext.Customers.FirstOrDefault(s => s.CustomerId == id);
            customer!.CustomerId = id;
            if (findCustomer != null)
            {
                customerLocationDBContext.Entry(findCustomer).CurrentValues.SetValues(customer);
                customerLocationDBContext.SaveChanges();
            }
            return customer;
        }

        public bool IsAddressEmpty(string street,string city,string zipcode,string state,string country) 
        {
            if (string.IsNullOrEmpty(street) && string.IsNullOrEmpty(city) && string.IsNullOrEmpty(zipcode)
                    && string.IsNullOrEmpty(state) && string.IsNullOrEmpty(country)) 
            {
                return true;
            }
            return false;
        }
    }
}
