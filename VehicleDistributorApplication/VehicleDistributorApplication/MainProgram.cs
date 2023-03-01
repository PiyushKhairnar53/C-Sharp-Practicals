
using VehicleDistributorApplication;

namespace VehicleDistributorSystem
{
    public class VehicleDistributor
    {
        public static void Main(string[] args)
        {

            string? vehicleNameToFind;
            Vehicle vehicle= new Vehicle();
            vehicle.GetBrandName();

            if (vehicle.vehicleType == "bike") 
            {
                vehicle.AddBike();
                vehicle.GetDistributor();
                Console.WriteLine("Please enter name of bike to find : ");
                vehicleNameToFind = Console.ReadLine();
                vehicle.CalculateVehiclePriceDetails(vehicleNameToFind!);
            }
            if (vehicle.vehicleType == "car")
            {
                vehicle.AddCar();
                vehicle.GetDistributor();
                Console.WriteLine("Please enter name of car to find : ");
                vehicleNameToFind = Console.ReadLine();
                vehicle.CalculateVehiclePriceDetails(vehicleNameToFind!);

            }
            if (vehicle.vehicleType == "both") 
            {
                vehicle.AddBoth();  
                vehicle.GetDistributor();
                Console.WriteLine("Please enter name of bike or car to find : ");
                vehicleNameToFind = Console.ReadLine();
                vehicle.CalculateVehiclePriceDetails(vehicleNameToFind!);

            }
        }
    }
}