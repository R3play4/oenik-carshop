﻿// <copyright file="ILogic.cs" company="PlaceholderCompany">
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
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<object> GetExtraModelLogic();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<object> GetCountryBrandLogic();
        IEnumerable<model_extra_connection> GetConnectionLogic();


        /// <summary>
        /// Method will call the repository method that will create new brand in the database.
        /// </summary>
        /// <param name="brand">new brand that needs to be created</param>
        void CreateBrandLogic(string name , string country, string url, string date, string revenue);

        /// <summary>
        /// Method will call the repository method that will create new brand in the database.
        /// </summary>
        /// <param name="model">new model that will be created.</param>
        void CreateModelLogic(string id, string name, string start_date, string engine_size, string horsepower, string price);

        /// <summary>
        /// Method will call the repository method that will create new extra in the database.
        /// </summary>
        /// <param name="extra">new extra that will be created.</param>
        void CreateExtraLogic(string categoryName, string extraName, string color, string price, string reusable);

        /// <summary>
        /// Method will call the repository method that will delete the brand based on the name.
        /// </summary>
        /// <param name="id">Id of the brand that needs to be deleted </param>
        void DeleteBrand(string selection);

        /// <summary>
        /// Method will call the repository method that will delete the model based on the name.
        /// </summary>
        /// <param name="id">ID of the model that needs to be deleted</param>
        void DeleteModel(string selection);

        /// <summary>
        /// Method will call the repository method that will delete the extra based on the id.
        /// </summary>
        /// <param name="id">ID of the extra that needs to be deleted</param>
        void DeleteExtra(string selection);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void DeleteConnection(string selection);

        /// <summary>
        /// Method will call respository method that will update the brand.
        /// </summary>
        void UpdateBrandLogic(string id, string name, string country, string founded, string revenue);

        void UpdateModelLogic(string selected, string name, string productionStart, string engineSizem, string horsePower, string startingPrice);
        void UpdateExtraLogic(string selected, string catname, string name, string price, string newReuse);
    }
}
