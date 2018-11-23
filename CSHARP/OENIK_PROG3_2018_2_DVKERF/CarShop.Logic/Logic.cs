﻿namespace CarShop.Logic
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
            this.repository = new Repository();
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
        /// Calls Repository List Extra
        /// </summary>
        public IEnumerable<extra> GetExtraLogic()
        {
            IEnumerable<extra> extras = this.repository.GetExtraRepo();
            return extras;
        }

        /// <summary>
        /// Calls Repository List Model
        /// </summary>
        public IEnumerable<car_models> GetModelsLogic()
        {
            IEnumerable<car_models> models = this.repository.GetModelsRepo();
            return models;
        }

        /// <summary>
        /// Calls CreateBrand method of the repository
        /// </summary>
        /// <param name="brand">new brand parameter that was gathered form the user in the Console Layer</param>
        public void CreateBrandLogic(car_brands brand)
        {
            this.repository.CreateBrandRepo(brand);
        }

        /// <summary>
        /// Calls CreateModel method of the repository
        /// </summary>
        /// <param name="model">new model parameter. It properties is empty at this point.</param>
        public void CreateModelLogic(car_models model)
        {
            this.repository.CreateModelRepo(model);
        }

        /// <summary>
        /// Calls DeleteBrand method of repository.
        /// </summary>
        /// <param name="name">name of the brand that needs to be deleted</param>
        public void DeleteBrand(string name)
        {
            this.repository.DeleteBrandRepo(name);
        }
    }
}
