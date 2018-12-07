// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Repository;
    using Data;
    using System.Collections;

    /// <summary>
    /// Implements ILogic CRUD operations
    /// </summary>
    public class Logic : ILogic
    {
        /// <summary>
        /// This will enable to communication with the Repository .dll
        /// </summary>
        private IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// </summary>
        public Logic()
        {
            this.SetRepositoryInterface(new Repository());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Alternative constuctor for mocking
        /// </summary>
        /// <param name="repository">IRepository interface</param>
        public Logic(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Sets the Repository property of the class. This will be used for mocking.
        /// </summary>
        /// <param name="intf">Repositary interface</param>
        public void SetRepositoryInterface(IRepository intf)
        {
            this.repository = intf;
        }

        /// <summary>
        /// Gets list of car brands from repo
        /// </summary>
        /// <returns>Enumerable list of car brands that was received from the repository </returns>
        public IEnumerable<car_brands> GetBrandsLogic()
        {
            IEnumerable<car_brands> brands = this.repository.GetBrandsRepo();
            return brands;
        }

        /// <summary>
        /// Gets list of extras from the repo
        /// </summary>
        /// <returns>List of extras from the repo</returns>
        public IEnumerable<extra> GetExtraLogic()
        {
            IEnumerable<extra> extras = this.repository.GetExtraRepo();
            return extras;
        }

        /// <summary>
        /// Gets a list of models from the repo
        /// </summary>
        /// <returns>List of models from the repo</returns>
        public IEnumerable<car_models> GetModelsLogic()
        {
            IEnumerable<car_models> models = this.repository.GetModelsRepo();
            return models;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetExtraModelLogic()
        {
            IEnumerable<car_models> models = this.repository.GetModelsRepo();
            IEnumerable<extra> extras = this.repository.GetExtraRepo();
            IEnumerable<model_extra_connection> connections = this.repository.GetExtraConnectionRepo();

            var result = from con in connections
                         join mod in models on con.model_id equals mod.id
                         join ext in extras on con.extra_id equals ext.id
                         select new { ID = con.id, Model = mod.name, Extra = ext.name };
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetCountryBrandLogic()
        {
            IEnumerable<car_brands> brands = this.repository.GetBrandsRepo();
            IEnumerable<car_models> models = this.repository.GetModelsRepo();

            var result = from br in brands
                         join mod in models on br.id equals mod.brand_id
                         select new { Country = br.country, FullName = br.name + " " + mod.name };

            return result;
        }

        /// <summary>
        /// Calls CreateBrand method of the repository
        /// </summary>
        /// <param name="brand">new brand parameter that was gathered form the user in the Console Layer</param>
        public void CreateBrandLogic(string name, string country, string url, DateTime date, int revenue)
        {
            car_brands newBrand = new car_brands()
            {
                name = name,
                country = country,
                url = url,
                founded = date,
                yearly_revenue = revenue
            };

            this.repository.CreateBrandRepo(newBrand);
        }

        /// <summary>
        /// Calls CreateModel method of the repository
        /// </summary>
        /// <param name="model">new model parameter. It properties is empty at this point.</param>
        public void CreateModelLogic(int id, string name, DateTime start_date, int engine_size, int horsepower, int price)
        {
            car_models newModel = new car_models()
            {
                brand_id = id,
                name = name,
                production_start = start_date,
                engine_size = engine_size,
                horsepower = horsepower,
                starting_price = price
            };

            this.repository.CreateModelRepo(newModel);
        }

        public void CreateExtraLogic(extra newExtra)
        {
            this.repository.CreateExtraRepo(newExtra);
        }

        /// <summary>
        /// Calls DeleteBrand method of repository.
        /// </summary>
        /// <param name="name">name of the brand that needs to be deleted</param>
        public void DeleteBrand(int id)
        {
            this.repository.DeleteBrandRepo(id);
        }

        /// <summary>
        /// Calls DeleteModel method of repository.
        /// </summary>
        /// <param name="name">name of the brand that needs to be deleted</param>
        public void DeleteModel(int id)
        {
            this.repository.DeleteModelRepo(id);
        }

        /// <summary>
        /// Calls DeleteExtra method of repository.
        /// </summary>
        /// <param name="id">id of the extra that needs to be deleted</param>
        public void DeleteExtra(int id)
        {
            this.repository.DeleteExtraRepo(id);
        }

        /// <summary>
        ///  Calls the Repository Method to update the database.
        /// </summary>
        /// <param name="name">updated name </param>
        /// <param name="country">updated country </param>
        /// <param name="founded">updated foundation date</param>
        /// <param name="revenue">updated revenue</param>
        public void UpdateBrandLogic(int id, string name, string country, string founded, string revenue)
        {
            this.repository.UpdateBrandRepo(id, name, country, founded, revenue);
        }

        /// <summary>
        /// Calls the Repository Method to update the database.
        /// </summary>
        /// <param name="selected"> selected model's id </param>
        /// <param name="brand_id"> new model's brand id</param>
        /// <param name="name"> updated name</param>
        /// <param name="productionStart">updated start date time </param>
        /// <param name="engineSizem">updated engine size</param>
        /// <param name="horsePower">updated horsepower</param>
        /// <param name="startingPrice">updated starting price</param>
        public void UpdateModelLogic(int selected, int brand_id, string name, string productionStart, string engineSize, string horsePower, string startingPrice)
        {
            this.repository.UpdateModelRepo(selected, brand_id, name, productionStart, engineSize, horsePower, startingPrice);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selected"></param>
        /// <param name="catname"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="newReuse"></param>
        public void UpdateExtraLogic(int selected, string catname, string name, string price, string newReuse)
        {
            this.repository.UpdateExtraRepo(selected, catname, name, price , newReuse);
        }
    }
}
