
using System;
using System.Runtime.CompilerServices;
using VehicleDistributorApplication;

namespace VehicleDistributorSystem
{
    public class Vehicle:Distributor
    {
        public int totalNoOfVehicles;
        

        public Vehicle() { }

        public void GetVehicleNames()
        {
            int bikesOfBoth, carsOfBoth;

            vehiclesDetails = new string[totalNoOfVehicles, 3];
            string title;

            if (vehicleType == "both")
            {
                Console.WriteLine("How many bikes of " + brandName + " do you want to add : ");
                bikesOfBoth = int.Parse(Console.ReadLine());
                carsOfBoth = totalNoOfVehicles - bikesOfBoth;

                //for bikes of both
                for (int i = 0; i < bikesOfBoth; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        if (j == 0)
                        {
                            title = "Name";
                        }
                        else if (j == 1)
                        {
                            title = "Price";
                        }
                        else
                        {
                            title = "Type";
                        }

                        if (j == 0)
                        {
                            string? nameOfBike;
                            do
                            {
                                Console.WriteLine("Please enter {0} of bike {1} : ", title, i + 1);
                                nameOfBike = Console.ReadLine();
                            } while (nameOfBike.Length == 0);
                            vehiclesDetails[i, j] = nameOfBike;
                        }

                        if (j == 1)
                        {
                            string? priceOfBike;
                            bool valid = false;
                            do
                            {
                                Console.WriteLine("Please enter {0} of bike {1} : ", title, i + 1);
                                priceOfBike = Console.ReadLine();
                                int price = 0;
                                bool inputIsNumber = Int32.TryParse(priceOfBike, out price);
                                if (inputIsNumber && price > 0)
                                {
                                    valid = true;
                                    break;
                                }
                                valid = false;
                                Console.WriteLine("You entered wrong input...");
                            } while (valid == false);
                            vehiclesDetails[i, j] = priceOfBike;
                        }

                        if (j == 2)
                        {
                            vehiclesDetails[i, j] = "bike";
                        }
                    }
                }

                //for cars of both
                for (int i = bikesOfBoth; i < totalNoOfVehicles; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        if (j == 0)
                        {
                            title = "Name";
                        }
                        else if (j == 1)
                        {
                            title = "Price";
                        }
                        else
                        {
                            title = "Type";
                        }

                        if (j == 0)
                        {
                            string? nameOfCar;
                            do
                            {
                                Console.WriteLine("Please enter {0} of car : ", title);
                                nameOfCar = Console.ReadLine();
                            } while (nameOfCar.Length == 0);
                            vehiclesDetails[i, j] = nameOfCar;
                        }

                        if (j == 1)
                        {
                            string? priceOfBike;
                            bool valid = false;
                            do
                            {
                                Console.WriteLine("Please enter {0} of car {1} : ", title, i + 1);
                                priceOfBike = Console.ReadLine();
                                int price = 0;
                                bool inputIsNumber = Int32.TryParse(priceOfBike, out price);
                                if (inputIsNumber && price > 0)
                                {
                                    valid = true;
                                    break;
                                }
                                valid = false;
                                Console.WriteLine("You entered wrong input...");
                            } while (valid == false);
                            vehiclesDetails[i, j] = priceOfBike;
                        }

                        if (j == 2)
                        {
                            vehiclesDetails[i, j] = "car";
                        }
                    }
                }

            }
            else
            {

                for (int i = 0; i < totalNoOfVehicles; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        if (j == 0)
                        {
                            title = "Name";
                        }
                        else if (j == 1)
                        {
                            title = "Price";
                        }
                        else
                        {
                            title = "Type";
                        }

                        if (j == 0)
                        {
                            string? nameOfBike;
                            do
                            {
                                Console.WriteLine("Please enter {0} of vehicle {1} : ", title, i + 1);
                                nameOfBike = Console.ReadLine();
                            } while (nameOfBike.Length == 0);
                            vehiclesDetails[i, j] = nameOfBike;
                        }

                        if (j == 1)
                        {
                            string? priceOfBike;
                            bool valid = false;
                            do
                            {
                                Console.WriteLine("Please enter {0} of vehicle {1} : ", title, i + 1);
                                priceOfBike = Console.ReadLine();
                                int price = 0;
                                bool inputIsNumber = Int32.TryParse(priceOfBike, out price);
                                if (inputIsNumber && price > 0)
                                {
                                    valid = true;
                                    break;
                                }
                                valid = false;
                                Console.WriteLine("You entered wrong input...");
                            } while (valid == false);
                            vehiclesDetails[i, j] = priceOfBike;
                        }

                        if (j == 2)
                        {
                            vehiclesDetails[i, j] = vehicleType;
                        }
                    }
                }
            }
        }

        public void CalculateVehiclePriceDetails(string enterVehicleName)
        {

            int minCommission = 0;
            string distWithLowestComm = "";
            int vehicle_price = 0;
            string vehicle_name = "";

            for (int vehicle_row = 0; vehicle_row < totalNoOfVehicles; vehicle_row++)
            {
                for (int vehicle_col = 0; vehicle_col < 2; vehicle_col++)
                {
                    if (vehicle_col == 0)
                    {
                        vehicle_name = vehiclesDetails[vehicle_row, vehicle_col];
                        if (vehicle_name == enterVehicleName)
                        {
                            vehicle_price = int.Parse(vehiclesDetails[vehicle_row, 1]);
                            
                            for (int dist_row = 0; dist_row < totalNoOfDistributors; dist_row++)
                            {
                                minCommission = int.Parse(distributorDetails[dist_row, 1]);

                                for (int j = 0; j < 2; j++)
                                {
                                    if (int.Parse(distributorDetails[j, 1]) < minCommission)
                                    {
                                        distWithLowestComm = distributorDetails[j, 0];
                                        minCommission = int.Parse(distributorDetails[j, 1]);
                                    }
                                }
                            }
                            Console.WriteLine("Minimum commission - " + minCommission + "%");
                        }
                    }
                }
            }
            Console.WriteLine("Dealer for " + brandName + " " + enterVehicleName+ " with lowest price is availaible at " + distWithLowestComm + " dealers.");
            int finalPriceOfVehicle = vehicle_price + (vehicle_price * minCommission / 100);
            Console.WriteLine("With lowest price : " + finalPriceOfVehicle);
        }

        public void AddBike()
        {
            bool valid;
            do
            {
                Console.WriteLine("Please enter Total no of Bikes to add - ");
                string? input = Console.ReadLine();
                bool inputIsNumber = Int32.TryParse(input, out totalNoOfVehicles);
                if (inputIsNumber && totalNoOfVehicles > 0)
                {
                    valid = true;
                    break;
                }
                valid = false;
                Console.WriteLine("You entered wrong input...");
            } while (valid == false);

            Console.WriteLine("Total bikes - " + totalNoOfVehicles);
            GetVehicleNames();
        }

        public void AddCar()
        {
            bool valid;
            do
            {
                Console.WriteLine("Please enter Total no of cars you want add : ");
                string? input = Console.ReadLine();
                bool inputIsNumber = Int32.TryParse(input, out totalNoOfVehicles);
                if (inputIsNumber && totalNoOfVehicles > 0)
                {
                    valid = true;
                    break;
                }
                valid = false;
                Console.WriteLine("You entered wrong input...");
            } while (valid == false);

            Console.WriteLine("Total Cars - " + totalNoOfVehicles);
            GetVehicleNames();
        }

        public void AddBoth()
        {
            
            bool valid;
            do
            {
                Console.WriteLine("Please enter Total no of Vehicles you want add : ");
                string input = Console.ReadLine();
                bool inputIsNumber = Int32.TryParse(input, out totalNoOfVehicles);
                if (inputIsNumber && totalNoOfVehicles > 0)
                {
                    valid = true;
                    break;
                }
                valid = false;
                Console.WriteLine("You entered wrong input...");
            } while (valid == false);

            
            GetVehicleNames();
        }

    }

}
