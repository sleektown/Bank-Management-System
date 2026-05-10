using Bank_Management_System.Exceptions;
using Bank_Management_System.Interfaces;
using System    ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models
{
    internal class Account : IAccount
    {
        public string AccountNumber {get; private set;}
        public string HolderName { get; private set; }
        private double _balance;
        private readonly List<Transaction> Transactions = new List<Transaction>();
        public IReadOnlyList<Transaction> GetTransactions()
        {
            return Transactions;
        }

        internal Account(string accountNumber, string holderName, double balance)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentNullException("Account number cannot be null or empty.");
            }
            if(string.IsNullOrWhiteSpace(holderName)) 
            {
                throw new ArgumentNullException("Holder name cannot be null or empty.");
            }
            if(balance < 0)
            {
                throw new InvalidAmountException("Initial balance cannot be negative.");
            }
            this.AccountNumber = accountNumber;
            this.HolderName = holderName;
            this._balance = balance;
        }
        

        public double Deposit(double amount)
        {
            if(amount <= 0)
            {
                throw new InvalidAmountException("Deposit amount must be greater than zero.");
            }
            double balanceBefore = _balance;
            double balanceAfter = _balance + amount;
            _balance = balanceAfter;
            RecordTransaction(amount, Enums.TransactionType.Deposit, balanceBefore, balanceAfter);
            return _balance;
        }

        public virtual double Withdraw(double amount)
        {
            if(amount <= 0)
            {
                throw new InvalidAmountException("Withdrawal amount must be greater than zero.");
            }

            if(amount > _balance)
            {
                throw new InsufficientBalanceException("Insufficient balance for this withdrawal.");
            }
            double balanceBefore = _balance;
            double balanceAfter = _balance - amount;
            _balance = balanceAfter;
            RecordTransaction(amount, Enums.TransactionType.Withdraw, balanceBefore, balanceAfter);
            return _balance;
        }


        public double GetBalance()
        {
            return _balance;
        }

        private void  RecordTransaction(double amount, Enums.TransactionType transactionType, double balanceBefore, double balanceAfter)
        {
            Transaction transaction = new Transaction(transactionType, amount, balanceBefore, balanceAfter);
            Transactions.Add(transaction);
        }
    }
}
