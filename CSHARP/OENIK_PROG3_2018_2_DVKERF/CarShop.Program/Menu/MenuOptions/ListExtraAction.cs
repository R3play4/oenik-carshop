﻿// <copyright file="ListExtraAction.cs" company="PlaceholderCompany">
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
    /// Class that will call the List method.
    /// </summary>
    internal class ListExtraAction : IMenuAction
    {
        /// <summary>
        /// Executes the List Extra Action menu. This wil call the List Extra (Read) Method (CRUD)
        /// </summary>
        public void ExecuteMenuAction()
        {
            Console.Clear();
            Console.WriteLine("List Extra Menu is not ready yet");
        }
    }
}
