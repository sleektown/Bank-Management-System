using Bank_Management_System.Models;

namespace BankAPIs.Data
{
    public static class BankStorage
    {
        public static List<Account> Accounts { get; set; } = new List<Account>
        {
            new SavingsAccount("SAV123", "John Doe", 5000),
            new CurrentAccount("CUR123", "Jane Doe", 3000)
        };
    }
}
