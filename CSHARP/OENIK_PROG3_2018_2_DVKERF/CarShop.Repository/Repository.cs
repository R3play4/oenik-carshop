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
        /// Gets a list of Brands from the DB
        /// </summary>
        /// <returns>List of brands</returns>
        public IEnumerable<car_brands> GetBrandsRepo()
        {
            return this.database.car_brands;
        }

        /// <summary>
        /// Gets list of Extras from the db
        /// </summary>
        /// <returns>List of Extras</returns>
        public IEnumerable<extra> GetExtraRepo()
        {
            return this.database.extras;
        }

        /// <summary>
        /// Gets a list of models from the DB
        /// </summary>
        /// <returns>List of models</returns>
        public IEnumerable<car_models> GetModelsRepo()
        {
            return this.database.car_models;
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
        /// Creates new model in the Database based on the parameter.
        /// </summary>
        /// <param name="model">new model that needs to be created.</param>
        public void CreateModelRepo(car_models model)
        {
            this.database.car_models.Add(model);
            this.database.SaveChanges();
        }

        /// <summary>
        /// Creates new extra in the Database based on the parameter.
        /// </summary>
        /// <param name="newExtra">new extra that needs to be created.</param>
        public void CreateExtraRepo(extra newExtra)
        {
            this.database.extras.Add(newExtra);
            this.database.SaveChanges();
        }

        /// <summary>
        /// Deletes Brand from DB based on the brands name.
        /// </summary>
        /// <param name="name">Name of the brand that needs to be deleted has to be exact.</param>
        public void DeleteBrandRepo(string name)
        {

            var brand = this.database.car_brands
                   .Where(b => b.name == name).First();
            this.database.car_brands.Remove(brand);
            this.database.SaveChanges();

            //try
            //{
            //    var brand = this.database.car_brands
            //        .Where(b => b.name == name).First();
            //    this.database.car_brands.Remove(brand);
            //    this.database.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }

        /// <summary>
        /// Deletes Model from DB based on the model name.
        /// </summary>
        /// <param name="name">Name of the model that needs to be deleted has to be exact.</param>
        public void DeleteModelRepo(string name)
        {
            var model = this.database.car_models
                .Where(b => b.name == name)
                .First();
            this.database.car_models.Remove(model);
            this.database.SaveChanges();

        }

        private int SelectBrandForModel()
        {
            var valid_options = this.database.car_models.Select(i => i.id);
            Console.WriteLine("Please type the id of the desired brand");
            this.DisplayIdAndBrand();
            int selected = int.Parse(Console.ReadLine());

            if (valid_options.Contains(selected))
            {
                return selected;
            }
            else
            {
                Console.WriteLine("Invalid Id was selected. Please choose again");
                this.SelectBrandForModel();
            }

            return selected;
        }

        /// <summary>
        /// Displays Brands and ID-s so the user can select a brand.
        /// </summary>
        private void DisplayIdAndBrand()
        {
            var brands = this.database.car_brands.Select(b =>
            new
            {
                Id = b.id,
                Name = b.name
            });

            int i = 0;
            foreach (var brand in brands)
            {
                string header = string.Empty;
                if (i == 0)
                {
                    i++;
                    var properties = brand.GetType().GetProperties();

                    foreach (var prop in properties)
                    {
                        header += prop.Name + "\t";
                    }

                    Console.WriteLine(header);
                }

                Console.WriteLine("{0}\t{1}\t",brand.Id, brand.Name);
            }
        }
    }
}
