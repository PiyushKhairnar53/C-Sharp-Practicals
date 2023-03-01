
namespace BankApplication
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message)
        {
            Console.WriteLine("\n" + message);
        }
    }

    internal class BankOperations:BankDetails
    {
        public int totalAccountBalance = 0;
        int depositAmount;
        int withdrawAmount;

        public void UpdateBalacne() 
        {
            Console.WriteLine("\nDo you want to deposit amount(y/yes or n/no) : ");
            string? input;
            input = Console.ReadLine().ToLower();

            do
            {
                if (input == "y" || input == "yes")
                {
                    DepositAmount();
                }

                if (totalAccountBalance > 0)
                {
                    Console.WriteLine("Do you want to withdraw amount(y/yes or n/no) : ");
                    input = Console.ReadLine();
                    input!.ToLower();

                    if (input == "y" || input == "yes")
                    {
                        WithdrawAmount();
                    }
                }

                if (input == "y" || input == "yes")
                {

                    Console.WriteLine("Do you want to deposit again (y/yes or n/no) : ");
                    input = Console.ReadLine().ToLower();
                }

            } while (input == "y" || input == "yes");
        }

        public void DepositAmount() 
        {
            bool validAmount = false;
            do
            {
                Console.WriteLine("Please enter The amount of money to deposit : ");
                string? input = Console.ReadLine();  
                bool inputIsNumber = Int32.TryParse(input, out depositAmount);

                try
                {
                    if (inputIsNumber && depositAmount > 0 && depositAmount <= 100000)
                    {
                        totalAccountBalance = totalAccountBalance + depositAmount;
                        validAmount = true;
                        break;
                    }
                    else
                    {
                        validAmount = false;
                        if (depositAmount < 0)
                        {
                            throw new InvalidAmountException("Deposit Amount should be greater than 0");
                        }
                        else if (depositAmount > 100000)
                        {
                            throw new InvalidAmountException("Deposit Amount should be less than 100000");
                        }
                        else
                            throw new InvalidAmountException("Deposit Amount you have entered is invalid..");

                    }
                }
                catch (InvalidAmountException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally 
                {
                    Console.WriteLine("Account balance : " + totalAccountBalance);
                }
            } while (validAmount == false);
    }

        public void WithdrawAmount() 
        {
            bool validAmount = false;
            do
            {
                Console.WriteLine("Please enter The amount of money to withdraw : ");
                string? input = Console.ReadLine();
                bool inputIsNumber = Int32.TryParse(input, out withdrawAmount);

                try
                {
                    if (inputIsNumber && withdrawAmount > 0 && withdrawAmount < 50000)
                    {
                        if (withdrawAmount <= totalAccountBalance)
                        {
                            totalAccountBalance = totalAccountBalance - withdrawAmount;
                            validAmount = true;
                            break;
                        }
                        else 
                        {
                            throw new InvalidAmountException("Your account balance is low..");
                        }
                    }
                    else
                    {
                        validAmount = false;
                        if (withdrawAmount < 0)
                        {
                            throw new InvalidAmountException("Withdraw Amount should be greater than 0");
                        }
                        else if (withdrawAmount > 50000)
                        {
                            throw new InvalidAmountException("Daily withdraw limit is 50000");
                        }
                        else
                            throw new InvalidAmountException("The amount you want to withdraw is invalid");
                    }
                }
                catch (InvalidAmountException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    Console.WriteLine("Account balance : " + totalAccountBalance);
                }

            } while (validAmount == false);
        }
    }
}
