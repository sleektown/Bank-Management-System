using Bank_Management_System.Exceptions;
using Bank_Management_System.Models;

internal class Program
{
    internal static void ShowMenu()
    {
        Console.WriteLine("Choose the operation: ");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Check Balance");
        Console.WriteLine("4. Transaction History");
        Console.WriteLine("5. Exit");
    }
    internal static int ReadInput()
    {

        if (!int.TryParse(Console.ReadLine(), out int userinput))
        {
            throw new InvalidOption("Invalid option selected, try again...");
        }

        else if (userinput != 1 && userinput != 2 && userinput != 3 && userinput != 4 && userinput != 5)
        {
            throw new InvalidOption("Invalid option selected, try again...");
        }
        return userinput;
    }
    internal static double ReadAmount()
    {
        if (!double.TryParse(Console.ReadLine(), out double amount))
        {
            throw new InvalidAmountException("Invalid amount entered, try again...");
        }
        return amount;
    }

    internal static void ProcessTransaction(Account account, int userinput)
    {
        if (userinput == 1)
        {
            Console.WriteLine("You have chosen to Deposit. Enter the amount to deposit: ");
            double amount = ReadAmount();
            Console.WriteLine("New Balance after Deposit: " + account.Deposit(amount));
        }

        else if (userinput == 2)
        {
            Console.WriteLine("You have chosen to Withdraw. Enter the amount to withdraw: ");
            double amount = ReadAmount();
            Console.WriteLine("New Balance after Withdrawal: " + account.Withdraw(amount));
        }

        else if (userinput == 3)
        {
            Console.WriteLine("Your current balance is: " + account.GetBalance());
        }
        else if (userinput == 4)
        {
            Console.WriteLine("Transaction History: ");
            foreach(var transaction in account.GetTransactions())
            {
                Console.WriteLine($"{transaction.TransactionTime}: {transaction.TransactionType} of Rs {transaction.Amount}, Balance before: Rs {transaction.BalanceBeforeTransaction}, Balance after: Rs {transaction.BalanceAfterTransaction}");
            }   
        }
    }


    public static void Main(string[] args)
    {
        bool running = true;
        Account ac1;
        try
        {
            ac1 = new SavingsAccount("UCBA1898765432", "John Doe", 2000);
            Console.WriteLine($"Account Number: {ac1.AccountNumber}");
            Console.WriteLine($"Account Holder: {ac1.HolderName}");
        }
        catch(Exception ex)
        {
            Console.WriteLine("An error occurred while creating the account: " + ex.Message);
            return; // Exit the program if account creation fails
        }


        while (running)
        {
            try
            {
                ShowMenu();
                int userinput = ReadInput();
                if (userinput == 5)
                {
                    running = false;
                }
                else
                {
                    ProcessTransaction(ac1, userinput);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        Console.WriteLine("Thank you for using our banking system.");
    }
}