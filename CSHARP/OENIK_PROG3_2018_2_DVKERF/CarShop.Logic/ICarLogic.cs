// <copyright file="ICarLogic.cs" company="PlaceholderCompany">
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
    public interface ICarLogic
    {
        /// <summary>
        /// Gets brand list from Repository
        /// </summary>
        /// <returns>List of Brands</returns>
        IEnumerable<car_brands> ListBrandLogic();

        /// <summary>
        /// Gets Models from Repository
        /// </summary>
        /// <returns>Reutrns list of models from the repository.</returns>
        IEnumerable<car_models> ListModelLogic();

        /// <summary>
        /// Gets Extras from the repository
        /// </summary>
        /// <returns>Returns a list of models from the repository </returns>
        IEnumerable<extra> ListExtraLogic();

        /// <summary>
        /// Gets the connection between the extra and the model from the repository.
        /// </summary>
        /// <returns>Returns a list of Extra and Model conencitons.</returns>
        IEnumerable<object> ListExtraModelLogic();

        /// <summary>
        /// Get Countries and Brands from the repository. Joins Brands and Modles table.
        /// </summary>
        /// <returns>Returns a list of objects from Brands and Models table. </returns>
        IEnumerable<object> ListCountryBrandLogic();

        /// <summary>
        /// Gets connections from extra model connecition table
        /// </summary>
        /// <returns>returns extra model connections</returns>
        IEnumerable<model_extra_connection> ListConnectionLogic();

        /// <summary>
        /// Joins car brands and car models and create a List of CarData Objects
        /// </summary>
        /// <returns>List of Car Data objects</returns>
        IEnumerable<CarData> ListFullNamePricesLogic();

        /// <summary>
        /// Checks the parameters of the new brand and forwards it to the repository if everything is correct.
        /// </summary>
        /// <param name="name">new name</param>
        /// <param name="country">new country</param>
        /// <param name="url">new url it can be null</param>
        /// <param name="foundationDate">new date </param>
        /// <param name="revenue">new reveneu </param>
        void CreateBrandLogic(string name, string country, string url, string foundationDate, string revenue);

        /// <summary>
        /// Checks the parameters of the new model and forwards it to the repository if everything is correct.
        /// </summary>
        /// <param name="brandId">new id of the brand of the model</param>
        /// <param name="name">new name</param>
        /// <param name="startDate">new production start date</param>
        /// <param name="engineSize">new engine size</param>
        /// <param name="horsePower">new horspower</param>
        /// <param name="price">new price</param>
        void CreateModelLogic(string brandId, string name, string startDate, string engineSize, string horsePower, string price);

        /// <summary>
        /// Checks the parameters of the new extra and forwards it to the repository if everything is correct.
        /// </summary>
        /// <param name="categoryName">new categpory name for the extra</param>
        /// <param name="extraName"> nam eof the new extra</param>
        /// <param name="color">color of the extra</param>
        /// <param name="price">new price </param>
        /// <param name="reusable">value of the reusable field of the new extra</param>
        void CreateExtraLogic(string categoryName, string extraName, string color, string price, string reusable);

        /// <summary>
        /// Checks if the Brand that needs to be deleted is proper. Searches based on Brand Id.
        /// </summary>
        /// <param name="selection">Id of the brand that needs to be deleted</param>
        void DeleteBrand(string selection);

        /// <summary>
        /// Checks if the Model that needs to be deleted is proper. Searches based on Model Id.
        /// </summary>
        /// <param name="selection">Id of the model that needs to be deleted.</param>
        void DeleteModel(string selection);

        /// <summary>
        /// Checks if the Extra that needs to be deleted is proper. Searches based on Extra Id.
        /// </summary>
        /// <param name="selection">Id of the extra that needs to be deleted.</param>
        void DeleteExtra(string selection);

        /// <summary>
        /// Checks if the Extra-Model connection that needs to be deleted is proper.
        /// </summary>
        /// <param name="selection">Id of the connection that needs to be deleted.</param>
        void DeleteConnection(string selection);

        /// <summary>
        /// Checks if the values that will be updated are properly set.
        /// </summary>
        /// <param name="newId">Id of the brand that needs to be updated.</param>
        /// <param name="name">Updated name</param>
        /// <param name="country">Updated country</param>
        /// <param name="founded">new foundation date</param>
        /// <param name="revenue">new revenu</param>
        void UpdateBrandLogic(string newId, string name, string country, string founded, string revenue);

        /// <summary>
        /// Checks if the values that will be updated are properly set.
        /// </summary>
        /// <param name="selected">Id of the model that will be updated.</param>
        /// <param name="name">updated name</param>
        /// <param name="productionStart">updated production start date</param>
        /// <param name="engineSize">Updated engine size</param>
        /// <param name="horsePower">Updated horsepower</param>
        /// <param name="startingPrice">Updated starting price</param>
        void UpdateModelLogic(string selected, string name, string productionStart, string engineSize, string horsePower, string startingPrice);

        /// <summary>
        /// Checks if the values that will be updated are properly set.
        /// </summary>
        /// <param name="selected">Id of the Extra that will be updated.</param>
        /// <param name="catName">Updated category name</param>
        /// <param name="name">updated extra name</param>
        /// <param name="price">updated price </param>
        /// <param name="newReuse">updated ruse field.</param>
        void UpdateExtraLogic(string selected, string catName, string name, string price, string newReuse);
    }
}
