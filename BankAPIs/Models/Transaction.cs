using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; private set; }
        public Enums.TransactionType TransactionType { get; private set; }

        public decimal Amount { get; private set; }

        public DateTime TransactionTime { get; private set; }

        public decimal BalanceAfterTransaction { get; private set; }
        public decimal BalanceBeforeTransaction { get; private set; }

        internal Transaction(Enums.TransactionType transactionType, decimal amount, decimal balanceBeforeTransaction, decimal balanceAfterTransaction)
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
