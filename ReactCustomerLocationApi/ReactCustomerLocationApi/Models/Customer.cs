using System.ComponentModel.DataAnnotations;

namespace ReactCustomerLocationApi.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string ContactNo { get; set; }

        public string? Street { get; set; } 

        public string? City { get; set; }

        public string? Zipcode { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

    }
}
