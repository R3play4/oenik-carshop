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
        /// Method will list Brands.
        /// </summary>
        void ListBrandsLogic();

        /// <summary>
        /// Method will List Models
        /// </summary>
        void ListModelsLogic();

        /// <summary>
        /// Method will List extras
        /// </summary>
        void ListExtraLogic();

        /// <summary>
        /// Method will call the repository method that will create new brand in the database.
        /// </summary>
        /// <param name="brand">new brand that needs to be created</param>
        void CreateBrandLogic(car_brands brand);

        /// <summary>
        /// Method will call the repository method that will delete the brand based on the name.
        /// </summary>
        /// <param name="name">Name of the brand that needs to be deleted </param>
        void DeleteBrand(string name);

    }
}
