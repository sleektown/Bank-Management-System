using Bank_Management_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models
{
    internal class CurrentAccount : Account
    {
        private const decimal overdraftLimit = 10000;

        internal CurrentAccount(string accountNumber, string holderName, decimal balance) : base(accountNumber, holderName, balance)
        {
        }

        protected override void ValidateWithdrawal(decimal amount)
        {
            
            if (GetBalance() - amount < -overdraftLimit)
            {
                throw new OverdraftLimitExceededException(
                    $"Withdrawal would exceed overdraft limit of Rs {overdraftLimit}/-");
            }
        }
        
    }
}
