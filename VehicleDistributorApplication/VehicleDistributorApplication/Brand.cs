namespace VehicleDistributorApplication
{
    public class Brand
    {
        public string? brandName;
        public string? vehicleType;
        public string[,] vehiclesDetails;
        public string[,] distributorDetails;

        public Brand() { }

        public void GetBrandName()
        {
           
            bool enterBrand = false;
            do
            {
                    
                Console.WriteLine("Please enter vehicle of which brand you want to add : ");
                
                brandName = Console.ReadLine();
                
                brandName.ToLower();
                   
                
                if (brandName == "hero" || brandName == "tvs" || brandName == "bajaj" || brandName == "vespa" || brandName == "yamaha" || brandName == "royal enfield")
                
                {
                    Console.WriteLine(brandName + " is a Bike Brand.");
                    vehicleType = "bike";
                    
                    Console.WriteLine(vehicleType + " is a Bike Brand.");
                    enterBrand = true;
                    
                }

                
                if (brandName == "toyota" || brandName == "tata" || brandName == "hyundai" || brandName == "mahindra")
                
                {                   
                    vehicleType = "car";
                    enterBrand = true;                       
                    
                }

                
                if (brandName == "honda" || brandName == "suzuki" || brandName == "bmw") 
                
                {
                    bool isValid = false;
                    
                    do
                    {  
                        Console.WriteLine(brandName + " sells both car and bike");
                        Console.WriteLine("What do you want to add bike/car/both : ");
                        vehicleType = Console.ReadLine().ToLower();
                        if (vehicleType == "bike")
                        {
                        
                            isValid = true;
                            
                            enterBrand= true;
                            
                        }
                        
                        else if (vehicleType == "car")
                        
                        {
                        
                            isValid = true;
                            
                            enterBrand = true;

                        }
                        
                        else if (vehicleType == "both")
                        
                        {
                        
                            isValid = true;
                            
                            enterBrand = true;

                        }
                        
                        else
                        {
                        
                            isValid = false;
                            
                            enterBrand = false;

                        }

                    } while (isValid == false);

                }

            } while (enterBrand == false);
        }
    }
}
