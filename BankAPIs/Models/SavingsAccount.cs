using Bank_Management_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models
{
    internal class SavingsAccount : Account
    {
        private const decimal MinBalance = 2000;

        public SavingsAccount(string accountNumber, string holderName, decimal balance) : base(accountNumber, holderName, balance) 
        {
            if (balance < MinBalance)
            {
                throw new MinimumBalanceViolationException($"Savings account must maintain minimum balance of Rs {MinBalance}/-");
            }
        }

        protected override void ValidateWithdrawal(decimal amount)
        {
            // Generic account validation
            base.ValidateWithdrawal(amount);

            // Savings account specific rule
            if (GetBalance() - amount < MinBalance)
            {
                throw new MinimumBalanceViolationException(
                    $"Withdrawal would result in balance below minimum required, minimum balance must be Rs {MinBalance}/-");
            }
        }
    }
}
