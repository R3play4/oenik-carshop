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
        /// Method will List Models
        /// </summary>
        IEnumerable<car_models> GetModelsLogic();

        /// <summary>
        /// Method will List extras
        /// </summary>
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
        /// Method will call the repository method that will delete the brand based on the name.
        /// </summary>
        /// <param name="name">Name of the brand that needs to be deleted </param>
        void DeleteBrand(string name);

    }
}
