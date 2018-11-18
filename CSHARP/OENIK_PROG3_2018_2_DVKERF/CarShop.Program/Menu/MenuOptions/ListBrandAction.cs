// <copyright file="ListBrandAction.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Program.Menu
{
    using Logic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that will call the List method.
    /// </summary>
    internal class ListBrandAction : IMenuAction
    {
        ILogic method;
        /// <summary>
        /// Executes the List Brand Action menu. This wil call the List Brand (Read) Method (CRUD)
        /// </summary>
        /// 
        public ListBrandAction()
        {
            method = new Logic();
        }
        public void ExecuteMenuAction()
        {
            Console.Clear();
            Console.WriteLine("Calling Logic Function");
            method.ListBrandsLogic();

        }
    }
}
