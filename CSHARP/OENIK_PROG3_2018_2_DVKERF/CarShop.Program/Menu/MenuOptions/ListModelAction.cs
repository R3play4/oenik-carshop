// <copyright file="ListModelAction.cs" company="PlaceholderCompany">
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
    internal class ListModelAction : IMenuAction
    {
        ILogic method; 
        /// <summary>
        /// Executes the List Model Action menu. This wil call the List Model (Read) Method (CRUD)
        /// </summary>
        public void ExecuteMenuAction()
        {
            Console.Clear();
            Console.WriteLine("Executing List Model Logic");
            method.ListModelsLogic();
        }
    }
}
