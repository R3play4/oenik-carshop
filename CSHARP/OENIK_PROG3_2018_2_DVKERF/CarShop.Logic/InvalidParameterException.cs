// <copyright file="InvalidParameterException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// If invalid parameter will be provided for one of the CRUD methods this exception will be thrown.
    /// </summary>
    [Serializable]
    public class InvalidParameterException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidParameterException"/> class.
        /// </summary>
        /// <param name="message">Message that will be presented to the user.</param>
        public InvalidParameterException(string message)
            : base(message)
        {
        }
    }
}
