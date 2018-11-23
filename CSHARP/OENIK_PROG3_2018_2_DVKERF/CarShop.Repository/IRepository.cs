// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;

    /// <summary>
    /// Declares CRUD operations. Comunicates with Data Entities.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets an enumerable list from the db that holds car brands
        /// </summary>
        /// <returns>List of car brands</returns>
        IEnumerable<car_brands> GetBrandsRepo();

        /// <summary>
        /// Gets all the models from the DB
        /// </summary>
        /// <returns>List of models</returns>
        IEnumerable<car_models> GetModelsRepo();

        /// <summary>
        /// Gets a list of Extras from the DB
        /// </summary>
        /// <returns>List of extras</returns>
        IEnumerable<extra> GetExtraRepo();

        /// <summary>
        /// Creates new brand in the database
        /// </summary>
        /// <param name="brand">name of the new brand</param>
        void CreateBrandRepo(car_brands brand);

        /// <summary>
        /// Creates new model in the database
        /// </summary>
        /// <param name="model">the new model that needs to be created.</param>
        void CreateModelRepo(car_models model);

        /// <summary>
        /// Creates new extra in the database
        /// </summary>
        /// <param name="newExtra">the new model that needs to be created.</param>
        void CreateExtraRepo(extra newExtra);

        /// <summary>
        /// Creates Brand from the databse based on the name parameter
        /// </summary>
        /// <param name="name">name of the brand that needs to be delted.</param>
        void DeleteBrandRepo(string name);
    }
}
