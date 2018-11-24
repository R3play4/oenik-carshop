﻿// <copyright file="DeleteExtra.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Console.MenuItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// DeleteExtra Menu Action
    /// </summary>
    internal class DeleteExtra : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteExtra"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public DeleteExtra(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            Console.WriteLine("Enter the id of the extra you would like to delete");
            int id = int.Parse(Console.ReadLine());

            this.LogicContact.DeleteExtra(id);
            Console.ReadLine();
        }
    }
}
