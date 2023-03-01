using System.Text.RegularExpressions;

namespace BankApplication
{
    internal class UserDetails
    {
        public string? firstName, lastName, email, contactNumber, gender, spouseName, maritualStatus;
        public bool haveSpouse, haveChilds;
        public int? numberOfChilds,userId=0;
        public List<String>? childNames;

        public UserDetails()
        {
            Random random = new();
            userId = random.Next(10000,999999);    
        }

        public void GetDetails() {

            do
            {
                Console.WriteLine("First name - ");
                firstName = Console.ReadLine();
            } while (firstName!.Length == 0);

            do
            {
                Console.WriteLine("Last name - ");
                lastName = Console.ReadLine();
            } while (lastName!.Length == 0);

            GetEmail();
            GetContact(); 
            GetGender();
            GetMaritualStatus();
        }

        public void GetDateOfBirth() 
        {
            Console.WriteLine("Enter your Date of Birth (DD/MM/YYYY) : ");
            string? dateOfBirth = Console.ReadLine();

            DateTime enteredDate = DateTime.Parse(dateOfBirth!);
        }

        public void GetEmail() {

            string valid ;
            do
            {
                Console.WriteLine("Please enter a valid Email id - ");
                email = Console.ReadLine();
                bool isEmail = Regex.IsMatch(email!, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                valid = isEmail ? "true" : "false";

            } while (valid == "false");
        }

        public void GetContact() {

            string valid;
            do
            {
                Console.WriteLine("Please enter a valid Contact No : ");
                contactNumber = Console.ReadLine();
                bool iscontactNumber = Regex.IsMatch(contactNumber!, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", RegexOptions.IgnoreCase);
                valid = iscontactNumber ? "true" : "false";

            } while (valid == "false");
        }

        public void GetGender() {

            bool valid = false;
            string? genderAnswer;
            do
            {
                Console.WriteLine("Enter gender (M/m or F/f): ");
                genderAnswer = (Console.ReadLine()).ToLower();
                if (genderAnswer == "m"|| genderAnswer == "male")
                {
                    gender = "male";
                    valid = true;
                }
                if (genderAnswer == "f" || genderAnswer == "female")
                {
                    gender = "female";
                    valid = true;   
                }
            } while(valid == false);
        }

        public void GetMaritualStatus() {

            Console.WriteLine("Are you married (y/Y or n/N) : ");
            string? m = Console.ReadLine();

            if (m == "y" || m == "Y" || m == "Yes" || m == "yes")
            {

                maritualStatus = "married";
                haveSpouse = true;

                Console.WriteLine("Please enter your spouse name - ");
                spouseName = Console.ReadLine();

                Console.WriteLine("Do you have childrens (y/Y or n/N) : ");
                string? childrensAnswer = (Console.ReadLine()).ToLower();
                if (childrensAnswer == "y" || childrensAnswer == "yes")
                {
                    haveChilds = true;
                    Console.WriteLine("Total no of childrens you have : ");
                    numberOfChilds = Convert.ToInt32(Console.ReadLine());
                    childNames = new List<string>((int)numberOfChilds);
                    for (int? i = 0; i < numberOfChilds; i++)
                    {
                        Console.WriteLine($"Enter Name of Child {i+1} : ");
                        childNames.Add(Console.ReadLine()!);
                    }
                }
            }else 
            {
                maritualStatus = "unmarried";
                haveSpouse = false;
            }
        }
    }
}
