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
        void ListExtra();
    }
}
