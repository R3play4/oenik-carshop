using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Logic
{
    public class InvalidDateFormatException : Exception
    {
        public InvalidDateFormatException(string message)
            : base(message)
        {
        }
    }
}
