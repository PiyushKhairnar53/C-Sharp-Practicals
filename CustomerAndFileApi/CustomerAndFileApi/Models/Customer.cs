namespace CustomerAndFileApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Locations>? Locations { get; set; } 
    }
}
