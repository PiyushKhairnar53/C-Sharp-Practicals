namespace CustomerAndFileApi.Models
{
    public class Customer
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Locations> Locations { get; set; }
    }
}
