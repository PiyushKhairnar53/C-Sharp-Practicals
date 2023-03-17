using CustomerLocationRPApi.Services.Models;

namespace CustomerLocationRPApi.Services.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer AddCustomerDetails(Customer customer);
        Customer UpdateCustomerDetails(int id,Customer customer);  
        Customer DeleteCustomerDetails(int id); 
    }

    public interface ICustomerLocationRepository 
    {
        Locations AddCustomerLocation(int id,Locations locations);
        Locations UpdateCustomerLocations(int id, int locationId, Locations location);
        Locations GetCustomerLocationById(int id,int locationId);
        Locations DeleteCustomerLocation(int id,int locationId);
    }

    public class CustomerLocationRepository : ICustomerRepository,ICustomerLocationRepository
    {
        private static List<Customer>? customersList;

        public CustomerLocationRepository()
        {
            customersList = new List<Customer>();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customersList!;
        }

        public Customer GetCustomerById(int id)
        {
            Customer? customer = customersList!.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return customer;
            }
            return null!;
        }

        public Customer AddCustomerDetails(Customer customer)
        {
            customer.Id = customersList!.Count > 0 ? customersList.Max(x => x.Id) + 1 : 1;
            try
            {
                customersList.Add(customer);
                return customer;   
            }
            catch (Exception exception)
            {
                return null!;
            }
        }

        public Customer UpdateCustomerDetails(int id,Customer newCustomer)
        {
            Customer? customer = customersList!.FirstOrDefault(c => c.Id == id);
            if (!string.IsNullOrEmpty(newCustomer?.Name))
            {
                customer!.Name = newCustomer.Name;
                if (newCustomer?.Locations != null && newCustomer.Locations.Any())
                {
                    customer!.Locations = newCustomer.Locations;
                }
                return customer!;
            }
            return null!;
        }

        public Customer DeleteCustomerDetails(int id)
        {
            Customer? customer = customersList!.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                if (customer.Locations != null && customer.Locations.Any())
                {
                    return customer;
                }
                if (customersList.Contains(customer))
                {
                    customersList.Remove(customer);
                    return customer;
                }
            }
            return null!;
        }

        public Locations AddCustomerLocation(int id, Locations location)
        {
            foreach (Customer customer in customersList!)
            {
                if (customer.Id == id)
                {
                    if (customer.Locations == null)
                    {
                        customer.Locations = new List<Locations>();
                    }
                    location.Id = customer.Locations!.Count > 0 ? customer.Locations.Max(x => x.Id) + 1 : 1;
                    customer.Locations!.Add(location);
                    return location;
                }
            }
            return null!;
        }

        public Locations UpdateCustomerLocations(int id, int locationId, Locations location)
        {
            foreach (Customer customer in customersList)
            {
                if (customer.Id == id)
                {
                    foreach (Locations currentLocation in customer.Locations)
                    {
                        if (currentLocation.Id == locationId)
                        {
                            currentLocation.Id = locationId;
                            currentLocation.City = location.City;
                            currentLocation.Address = location.Address;
                            return currentLocation;
                        }
                    }
                }
            }
            return null!;
        }

        public Locations GetCustomerLocationById(int id, int locationId)
        {
            foreach (Customer customer in customersList)
            {
                List<Locations> customerLocations = new List<Locations>();

                if (customer.Id == id)
                {
                    foreach (Locations location in customer.Locations)
                    {
                        if (location.Id == locationId)
                        {
                            return location;
                        }
                    }
                }
            }
            return null!;   
        }

        public Locations DeleteCustomerLocation(int id, int locationId)
        {
            foreach (Customer customer in customersList!)
            {
                if (customer.Id == id)
                {
                    List<Locations> oldCustomerLocations = new List<Locations>();
                    foreach (Locations location in customer.Locations!)
                    {
                        oldCustomerLocations.Add(location);
                    }
                    Locations itemToRemove = oldCustomerLocations.Single(r => r.Id == locationId);
                    if (oldCustomerLocations.Contains(itemToRemove))
                    {
                        oldCustomerLocations.Remove(itemToRemove);
                        customer.Locations = oldCustomerLocations;
                        return itemToRemove;
                    }
                }
            }
            return null!;
        }
    }
}
