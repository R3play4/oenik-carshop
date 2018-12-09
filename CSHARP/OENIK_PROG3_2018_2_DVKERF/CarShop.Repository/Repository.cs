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
    using System.Data.Entity.Infrastructure;

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
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<model_extra_connection> GetExtraConnectionRepo()
        {
            return this.database.model_extra_connection;
        }

        /// <summary>
        /// Creates new brand in the Database based on the parameter.
        /// </summary>
        /// <param name="brand">new brand parameter.</param>
        public void CreateBrandRepo(car_brands brand)
        {
            try
            {
                int last_id = this.database.car_brands.Max(i => i.id);
                brand.id = last_id + 1;
                this.database.car_brands.Add(brand);
                this.database.SaveChanges();
                //return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //return false;
            }
        }

        /// <summary>
        /// Creates new model in the Database based on the parameter.
        /// </summary>
        /// <param name="model">new model that needs to be created.</param>
        public void CreateModelRepo(car_models model)
        {
            int last_id = this.database.car_models.Max(i => i.id);
            model.id = last_id + 1;
            this.database.car_models.Add(model);
            this.database.SaveChanges();
        }

        /// <summary>
        /// Creates new extra in the Database based on the parameter.
        /// </summary>
        /// <param name="newExtra">new extra that needs to be created.</param>
        public void CreateExtraRepo(extra newExtra)
        {
            int last_id = this.database.extras.Max(i => i.id);
            newExtra.id = last_id + 1;
            this.database.extras.Add(newExtra);
            this.database.SaveChanges();
        }

        /// <summary>
        /// Deletes Brand from DB based on the brands name.
        /// </summary>
        /// <param name="name">Name of the brand that needs to be deleted has to be exact.</param>
        public void DeleteBrandRepo(car_brands brand)
        {
            try
            {
                this.database.car_brands.Remove(brand);
                this.database.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.InnerException.InnerException.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Deletes Model from DB based on the model name.
        /// </summary>
        /// <param name="name">Name of the model that needs to be deleted has to be exact.</param>
        public void DeleteModelRepo(car_models model)
        {
            try
            {
                this.database.car_models.Remove(model);
                this.database.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.InnerException.InnerException.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Deletes Extra from DB based on the model name.
        /// </summary>
        /// <param name="id">Name of the model that needs to be deleted has to be exact.</param>
        public void DeleteExtraRepo(extra extra)
        {
            try
            {
                this.database.extras.Remove(extra);
                this.database.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.InnerException.InnerException.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteConnectionRepo(model_extra_connection connection)
        {
            try
            {
                this.database.model_extra_connection.Remove(connection);
                this.database.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.InnerException.InnerException.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="founded"></param>
        /// <param name="revenue"></param>
        public void UpdateBrandRepo(int id, string name, string country, DateTime? founded, int? revenue)
        {
            // returns the selected brand
            car_brands brand = this.database.car_brands
                .Where(b => b.id == id).First();

            if (name != string.Empty)
            {
                brand.name = name;
            }

            if (country != string.Empty)
            {
                brand.country = country;
            }

            if (founded != default(DateTime))
            {
                brand.founded = founded;
            }

            if (revenue != default(int))
            {
                brand.yearly_revenue = revenue;
            }

            Console.ReadLine();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selected"></param>
        /// <param name="brand_id"></param>
        /// <param name="name"></param>
        /// <param name="productionStart"></param>
        /// <param name="engineSizem"></param>
        /// <param name="horsePower"></param>
        /// <param name="startingPrice"></param>
        public void UpdateModelRepo(int selected, string name, DateTime? productionStart, int? engineSize, int? horsePower, int? startingPrice)
        {
            car_models model = this.database.car_models
                .Where(m => m.id == selected).First();

            if (name != string.Empty)
            {
                model.name = name;
            }

            if (productionStart != default(DateTime))
            {
                model.production_start = productionStart;
            }

            if (engineSize != default(int))
            {
                model.engine_size = engineSize;
            }

            if (horsePower != default(int))
            {
                model.horsepower = horsePower;
            }

            if (startingPrice != default(int))
            {
                model.starting_price = startingPrice;
            }

            this.database.SaveChanges();
        }

        public void UpdateExtraRepo(int selected, string catname, string name, int price, int newReuse)
        {
            extra extra = this.database.extras
                .Where(e => e.id == selected).First();

            if (catname != string.Empty)
            {
                extra.category_name = catname;
            }

            if (name != string.Empty)
            {
                extra.name = name;
            }

            if (price != default(int))
            {
                extra.price = price;
            }

            if (newReuse != default(int))
            {
                extra.reuseable = (byte)newReuse;
            }

            this.database.SaveChanges();
        }
    }
}
