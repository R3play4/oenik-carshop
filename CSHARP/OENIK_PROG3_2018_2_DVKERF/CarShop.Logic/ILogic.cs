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
        void CreateBrandLogic(string name , string country, string url, DateTime date, int revenue);

        /// <summary>
        /// Method will call the repository method that will create new brand in the database.
        /// </summary>
        /// <param name="model">new model that will be created.</param>
        void CreateModelLogic(int id, string name, DateTime start_date, int engine_size, int horsepower, int price);

        /// <summary>
        /// Method will call the repository method that will create new extra in the database.
        /// </summary>
        /// <param name="extra">new extra that will be created.</param>
        void CreateExtraLogic(extra extra);

        /// <summary>
        /// Method will call the repository method that will delete the brand based on the name.
        /// </summary>
        /// <param name="id">Id of the brand that needs to be deleted </param>
        void DeleteBrand(int id);

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

        /// <summary>
        /// Method will call respository method that will update the brand.
        /// </summary>
        void UpdateBrandLogic(int id, string name, string country, string founded, string revenue);

        void UpdateModelLogic(int selected, int brand_id, string name, string productionStart, string engineSizem, string horsePower, string startingPrice);
    }
}
