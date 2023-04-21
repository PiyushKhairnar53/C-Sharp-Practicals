using Microsoft.EntityFrameworkCore;
using ReactCustomerLocationApi.Models;

namespace ReactCustomerLocationApi.Data
{
    public class CustomerLocationDBContext:DbContext
    {
        public CustomerLocationDBContext(DbContextOptions option) : base(option) { }
        public DbSet<Customer> Customers { get; set; }

    }
}
