using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Exceptions
{
    internal class MinimumBalanceViolationException: Exception
    {
        public MinimumBalanceViolationException(string message) : base(message)
        {
        }
    }
}
