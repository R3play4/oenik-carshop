// <copyright file="ICarRepository.cs" company="PlaceholderCompany">
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
    public interface ICarRepository
    {
        /// <summary>
        /// Gets an enumerable list from the db that holds car brands
        /// </summary>
        /// <returns>List of car brands</returns>
        IEnumerable<CarBrands> ListBrandsRepo();

        /// <summary>
        /// Gets all the models from the DB
        /// </summary>
        /// <returns>List of models</returns>
        IEnumerable<CarModels> ListModelsRepo();

        /// <summary>
        /// Gets a list of Extras from the DB
        /// </summary>
        /// <returns>List of extras</returns>
        IEnumerable<Extras> ListExtraRepo();

        /// <summary>
        /// Gets a list of Extra-Model connection from the DB.
        /// </summary>
        /// <returns>returns extra and model connections</returns>
        IEnumerable<ModelExtraConnection> ListExtraConnectionRepo();

        /// <summary>
        /// Creates new brand in the database
        /// </summary>
        /// <param name="brand">name of the new brand</param>
        void CreateBrandRepo(CarBrands brand);

        /// <summary>
        /// Creates new model in the database
        /// </summary>
        /// <param name="model">the new model that needs to be created.</param>
        void CreateModelRepo(CarModels model);

        /// <summary>
        /// Creates new extra in the database
        /// </summary>
        /// <param name="newExtra">the new model that needs to be created.</param>
        void CreateExtraRepo(Extras newExtra);

        /// <summary>
        /// Deletes Brand from the databse.
        /// </summary>
        /// <param name="brand">brand that needs to be delted.</param>
        void DeleteBrandRepo(CarBrands brand);

        /// <summary>
        /// Deletes Model from the databse.
        /// </summary>
        /// <param name="model">model that needs to be delted.</param>
        void DeleteModelRepo(CarModels model);

        /// <summary>
        /// Deletes Extra from the databse.
        /// </summary>
        /// <param name="extra">extra that needs to be delted.</param>
        void DeleteExtraRepo(Extras extra);

        /// <summary>
        /// Deletes Extra-Model connesction from the databse.
        /// </summary>
        /// <param name="connection">Connection that needs to be deleted.</param>
        void DeleteConnectionRepo(ModelExtraConnection connection);

        /// <summary>
        /// Calls repository to update selected brand.
        /// </summary>
        /// <param name="id">id of the brand that needs to be updated </param>
        /// <param name="name">updated name</param>
        /// <param name="country">updated country</param>
        /// <param name="founded">updated foundation date</param>
        /// <param name="revenue">updated revenue</param>
        void UpdateBrandRepo(int id, string name, string country, DateTime? founded, int? revenue);

        /// <summary>
        /// Gets the id of the Model that needs to be updated. Sets the new values based on the parameters.
        /// </summary>
        /// <param name="selected">id of the model that needs to be updated</param>
        /// <param name="name">updated name</param>
        /// <param name="productionStart">updated production start date.</param>
        /// <param name="engineSize">updated engine size.</param>
        /// <param name="horsePower">updated horsepower</param>
        /// <param name="startingPrice">updated starting price.</param>
        void UpdateModelRepo(int selected, string name, DateTime? productionStart, int? engineSize, int? horsePower, int? startingPrice);

        /// <summary>
        /// Gets the id of the Extra that needs to be updated. Sets the new values based on the parameters.
        /// </summary>
        /// <param name="selected">id of the extra that needs to be updated</param>
        /// <param name="catname">updated category name</param>
        /// <param name="name">updated name of the extra</param>
        /// <param name="price">updated price </param>
        /// <param name="newReuse">updated value of reuseable field.</param>
        void UpdateExtraRepo(int selected, string catname, string name, int price, int newReuse);
    }
}
