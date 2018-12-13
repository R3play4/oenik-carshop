// <copyright file="CarData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that holds Car full name and pricess. Will be used by the Java Endpoint.
    /// </summary>
    public class CarData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CarData"/> class.
        /// </summary>
        /// <param name="id">id of the car</param>
        /// <param name="fullname">full name of the car.</param>
        /// <param name="price">price of the car</param>
        public CarData(int id, string fullname, int? price)
        {
            this.Id = id;
            this.FullName = fullname;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets Id of a given Car
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets FullName of a car( Brand + Model name combo)
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets price of a car
        /// </summary>
        public int? Price { get; set; }
    }
}
