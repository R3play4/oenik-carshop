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
            var result = this.database.car_brands.Select(b =>
            new
            {
                ID = b.id,
                Name = b.name,
                Country = b.country,
                Founded = b.founded,
            });

            // blank line
            Console.WriteLine();

            // prints results
            int i = 0;
            foreach (var item in result)
            {
                // gets the properties of the first item
                if (i == 0)
                {
                    // headers will store the properties the will provide the header of the table.
                    string headers = string.Empty;
                    i++;
                    var properties = item.GetType().GetProperties();

                    foreach (var prop in properties)
                    {
                        if (prop.Name == "ID" || prop.Name == "Name")
                        {
                            headers += prop.Name + "\t";
                        }
                    }

                    Console.WriteLine(headers);
                }

                Console.WriteLine(string.Format("{0}\t{1}\t",item.ID,item.Name));
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
            try
            {
                this.database.car_brands.Add(brand);
                this.database.SaveChanges();
                Console.WriteLine("\nNew Brand was created successfully. Press Enter to continue.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
