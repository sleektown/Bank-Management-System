using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Exceptions
{
    internal class InvalidOption:Exception
    {
        public InvalidOption(string message) : base(message) { }
    }
}
