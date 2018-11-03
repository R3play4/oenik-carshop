// <copyright file="IMenuAction.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Program.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that is responsible for the MenuItem's actions.
    /// </summary>
    internal interface IMenuAction
    {
        /// <summary>
        /// Action to be implemented by a MenuItem.
        /// </summary>
        void ExecuteMenuAction();
    }
}
