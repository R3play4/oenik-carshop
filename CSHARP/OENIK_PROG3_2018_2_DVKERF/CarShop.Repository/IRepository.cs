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
        /// List Brands
        /// </summary>
        void ListBrandsRepo();

        /// <summary>
        /// List Models
        /// </summary>
        void ListModelsRepo();

        /// <summary>
        /// List Extras
        /// </summary>
        void ListExtraRepo();

        /// <summary>
        /// Creates new brand in the database
        /// </summary>
        /// <param name="brand">name of the new brand</param>
        void CreateBrandRepo(car_brands brand);

        /// <summary>
        /// Creates Brand from the databse based on the name parameter
        /// </summary>
        /// <param name="name">name of the brand that needs to be delted.</param>
        void DeleteBrandRepo(string name);
    }
}
