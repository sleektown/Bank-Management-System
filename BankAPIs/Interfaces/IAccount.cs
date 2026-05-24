using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Interfaces
{
    internal interface IAccount
    {
        decimal Deposit(decimal amount);

        decimal Withdraw(decimal amount);

        decimal GetBalance();
    }
}
