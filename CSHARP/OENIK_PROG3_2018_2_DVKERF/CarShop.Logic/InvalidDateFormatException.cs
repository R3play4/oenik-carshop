namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// If invalid date will be provided for one of the CRUD methods this exception will be thrown.
    /// </summary>
    public class InvalidDateFormatException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidDateFormatException"/> class.
        /// </summary>
        /// <param name="message">Message that will be presented to the user.</param>
        public InvalidDateFormatException(string message)
            : base(message)
        {
        }
    }
}
