using Bank_Management_System.Models;

namespace BankAPIs.Interfaces
{
    public interface IAccountService
    {
        decimal Deposit(string accountNumber, decimal amount);
        decimal Withdraw(string accountNumber, decimal amount);
        IReadOnlyList<Transaction> GetTransactions(string accountNumber);

    }
}
