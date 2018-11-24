// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;

    /// <summary>
    /// Interface for CRUD operations. Communicates with Repository.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Gets brand list from Repository
        /// </summary>
        /// <returns>List of Brands</returns>
        IEnumerable<car_brands> GetBrandsLogic();

        /// <summary>
        /// Gets Models from Repository
        /// </summary>
        /// <returns>Reutrns list of models from the repository.</returns>
        IEnumerable<car_models> GetModelsLogic();

        /// <summary>
        /// Gets Extras from the repository
        /// </summary>
        /// <returns>Returns a list of models from the repository </returns>
        IEnumerable<extra> GetExtraLogic();

        /// <summary>
        /// Method will call the repository method that will create new brand in the database.
        /// </summary>
        /// <param name="brand">new brand that needs to be created</param>
        void CreateBrandLogic(car_brands brand);

        /// <summary>
        /// Method will call the repository method that will create new brand in the database.
        /// </summary>
        /// <param name="model">new model that will be created.</param>
        void CreateModelLogic(car_models model);

        /// <summary>
        /// Method will call the repository method that will create new extra in the database.
        /// </summary>
        /// <param name="extra">new extra that will be created.</param>
        void CreateExtraLogic(extra extra);

        /// <summary>
        /// Method will call the repository method that will delete the brand based on the name.
        /// </summary>
        /// <param name="name">Name of the brand that needs to be deleted </param>
        void DeleteBrand(string name);

        /// <summary>
        /// Method will call the repository method that will delete the model based on the name.
        /// </summary>
        /// <param name="name">Name of the model that needs to be deleted</param>
        void DeleteModel(string name);

        /// <summary>
        /// Method will call the repository method that will delete the extra based on the id.
        /// </summary>
        /// <param name="id">ID of the extra that needs to be deleted</param>
        void DeleteExtra(int id);
    }
}
