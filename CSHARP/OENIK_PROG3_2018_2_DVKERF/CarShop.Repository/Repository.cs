// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;

    /// <summary>
    /// Implements CRUD operations. Comunicates with Data Entities.
    /// </summary>
    public class Repository : IRepository
    {
        /// <summary>
        /// database connection
        /// </summary>
        private CarShopDBaseEntities database;

        /// <summary>
        /// List Brands
        /// </summary>
        public void ListBrandsRepo()
        {
            // Linq for brand names
            var result = this.database.car_brands.Select(b => b.name);

            // blank line
            Console.WriteLine();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// List Extras
        /// </summary>
        public void ListExtraRepo()
        {
            // Linq for model names
            var result = this.database.car_models.Select(m => m.name);

            // blank line
            Console.WriteLine();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// List Models
        /// </summary>
        public void ListModelsRepo()
        {
            // Linq for model names
            var result = this.database.extras.Select(e => e.name);

            // blank line
            Console.WriteLine();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
