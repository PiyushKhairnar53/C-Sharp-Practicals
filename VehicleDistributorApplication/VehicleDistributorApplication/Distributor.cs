
namespace VehicleDistributorApplication
{
    public class Distributor:Brand
    {
        public int totalNoOfDistributors;

        public void GetDistributor()
        {
            bool validDistributors;
            do
            {
                Console.WriteLine("Please enter Total no of Distributors for {0} - ", brandName);
                string input = Console.ReadLine();
                bool inputIsNumber = Int32.TryParse(input, out totalNoOfDistributors);
                if (inputIsNumber && totalNoOfDistributors > 0)
                {
                    validDistributors = true;
                    break;
                }
                validDistributors = false;
                Console.WriteLine("You entered wrong input...");
            } while (validDistributors == false);

            distributorDetails = new string[totalNoOfDistributors, 3];
            string title;

            for (int i = 0; i < totalNoOfDistributors; i++)
            {
                string[] vehiclesSoldByDistributor;
                int totalNoOfVehicleSoldByDistributor;
                string? nameOfDistributor = "";

                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                        title = "Name";
                    else if (j == 1)
                        title = "Commission";
                    else
                        title = "Type";

                    if (j == 0)
                    {
                        do
                        {
                            Console.WriteLine("Please enter {0} of distributor : ", title);
                            nameOfDistributor = Console.ReadLine();
                        } while (nameOfDistributor.Length == 0);
                        distributorDetails[i, j] = nameOfDistributor;

                    }

                    if (j == 1)
                    {
                        string? commOfDistributor;
                        bool isValid = false;
                        do
                        {
                            Console.WriteLine("Please enter {0} of distributor : ", title);
                            commOfDistributor = Console.ReadLine();
                            int comm = 0;
                            bool inputIsNumber = Int32.TryParse(commOfDistributor, out comm);
                            if (inputIsNumber && comm > 0)
                            {
                                isValid = true;
                                break;
                            }
                            isValid = false;
                            Console.WriteLine("You entered wrong input...");
                        } while (isValid == false);
                        distributorDetails[i, j] = commOfDistributor;
                    }

                    if (j == 2) 
                    {
                        distributorDetails[i, j] = vehicleType;
                    }

                }

            }
        }


    }
}
