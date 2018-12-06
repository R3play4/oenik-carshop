﻿// <copyright file="Logic.cs" company="PlaceholderCompany">
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
        public void DeleteModel(string name)
        {
            this.repository.DeleteModelRepo(name);
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
        ///  Calls the Repository Method to update the database. Tests if any of the parameters are null.
        /// </summary>
        /// <param name="name">updated name </param>
        /// <param name="country">updated country </param>
        /// <param name="founded">updated foundation date</param>
        /// <param name="revenue">updated revenue</param>
        public void UpdateBrandLogic(int id, string name, string country, string founded, string revenue)
        {
            this.repository.UpdateBrandRepo(id, name, country, founded, revenue);
            
        }
    }
}
