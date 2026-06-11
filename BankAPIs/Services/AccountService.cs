using Bank_Management_System.Models;
using BankAPIs.Interfaces;
using BankAPIs.Data;
using BankAPIs.Exceptions;
using System.Linq;

namespace BankAPIs.Services
{
    public class AccountService : IAccountService
    {
        public decimal Deposit(string accountNumber, decimal amount)
        {
            var account = BankStorage.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new AccountNotFoundException("Account not found.");
            }

            decimal updatedBalance = account.Deposit(amount);
            return updatedBalance;
        }

        public IReadOnlyList<Transaction> GetTransactions(string accountNumber)
        {
            var account = BankStorage.Accounts.FirstOrDefault(a=> a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new AccountNotFoundException("Account not found.");
            }

            return account.GetTransactions();
        }

        public decimal Withdraw(string accountNumber, decimal amount)
        {
            var account = BankStorage.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new AccountNotFoundException("Account not found.");
            }

            decimal updatedBalance = account.Withdraw(amount);
            return updatedBalance;
        }
    }
}
