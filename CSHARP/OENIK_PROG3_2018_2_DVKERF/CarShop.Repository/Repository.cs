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
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        public Repository()
        {
            this.database = new CarShopDBaseEntities();
        }

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

        /// <summary>
        /// Creates new brand in the Database based on the parameter.
        /// </summary>
        /// <param name="brand">new brand parameter.</param>
        public void CreateBrandRepo(car_brands brand)
        {
            this.database.car_brands.Add(brand);
            this.database.SaveChanges();
        }

        /// <summary>
        /// Deltes Brand from DB based on the brands name.
        /// </summary>
        /// <param name="name">Name of the brand that needs to be deleted has to be exact.</param>
        public void DeleteBrandRepo(string name)
        {
            var brand = this.database.car_brands
                .Where(b => b.name == name).First();

            this.database.car_brands.Remove(brand);
            this.database.SaveChanges();
        }
    }
}
