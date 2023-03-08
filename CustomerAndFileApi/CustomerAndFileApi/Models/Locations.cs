using System;

namespace CustomerAndFileApi.Models
{
    public class Locations
    {
        public int custId { get; set; }
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }

    public class LocationList
    {
        public List<Locations> locations { get; set; } = new List<Locations>();

    }
}
