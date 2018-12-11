// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
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
        /// Gets a list of Extra-Model connection from the DB.
        /// </summary>
        /// <returns>returns extra and model connections</returns>
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
        /// Deletes Brand from the databse.
        /// </summary>
        /// <param name="brand">brand that needs to be delted.</param>
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
        /// Deletes Model from the databse.
        /// </summary>
        /// <param name="model">model that needs to be delted.</param>
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
        /// Deletes Extra from the databse.
        /// </summary>
        /// <param name="extra">extra that needs to be delted.</param>
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
        /// Deletes Extra-Model connesction from the databse.
        /// </summary>
        /// <param name="connection">Connection that needs to be deleted.</param>
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
        /// Calls repository to update selected brand.
        /// </summary>
        /// <param name="id">id of the brand that needs to be updated </param>
        /// <param name="name">updated name</param>
        /// <param name="country">updated country</param>
        /// <param name="founded">updated foundation date</param>
        /// <param name="revenue">updated revenue</param>
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

        /// <summary>
        /// Gets the id of the Model that needs to be updated. Sets the new values based on the parameters.
        /// </summary>
        /// <param name="selected">id of the model that needs to be updated</param>
        /// <param name="name">updated name</param>
        /// <param name="productionStart">updated production start date.</param>
        /// <param name="engineSize">updated engine size.</param>
        /// <param name="horsePower">updated horsepower</param>
        /// <param name="startingPrice">updated starting price.</param>
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

        /// <summary>
        /// Gets the id of the Extra that needs to be updated. Sets the new values based on the parameters.
        /// </summary>
        /// <param name="selected">id of the extra that needs to be updated</param>
        /// <param name="catname">updated category name</param>
        /// <param name="name">updated name of the extra</param>
        /// <param name="price">updated price </param>
        /// <param name="newReuse">updated value of reuseable field.</param>
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
