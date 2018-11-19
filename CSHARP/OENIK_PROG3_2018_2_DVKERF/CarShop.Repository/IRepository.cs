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
    }
}
