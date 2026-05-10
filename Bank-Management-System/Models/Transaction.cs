using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models
{
    internal class Transaction
    {
        internal Guid TransactionId { get; private set; }
        internal Enums.TransactionType TransactionType { get; private set; }

        internal double Amount { get; private set; }

        internal DateTime TransactionTime { get; private set; }

        internal double BalanceAfterTransaction { get; private set; }
        internal double BalanceBeforeTransaction { get; private set; }

        internal Transaction(Enums.TransactionType transactionType, double amount, double balanceBeforeTransaction, double balanceAfterTransaction)
        {
            this.TransactionId = Guid.NewGuid();
            this.TransactionType = transactionType;
            this.Amount = amount;
            this.TransactionTime = DateTime.UtcNow;
            this.BalanceBeforeTransaction = balanceBeforeTransaction;
            this.BalanceAfterTransaction =  balanceAfterTransaction;
        }
    }
}
