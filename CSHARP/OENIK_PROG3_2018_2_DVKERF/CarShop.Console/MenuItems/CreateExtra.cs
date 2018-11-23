﻿// <copyright file="CreateExtra.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Console.MenuItems
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Create Extra Menu Action
    /// </summary>
    internal class CreateExtra : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateExtra"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public CreateExtra(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            extra newExtra = new extra();

            Console.WriteLine("Category:");
            newExtra.category_name = Console.ReadLine();

            Console.WriteLine("Name:");
            newExtra.name = Console.ReadLine();

            Console.WriteLine("Price:");
            newExtra.price = int.Parse(Console.ReadLine());

            Console.WriteLine("Color:");
            newExtra.color = Console.ReadLine();

            Console.WriteLine("Reuseable: ");
            newExtra.reuseable = byte.Parse(Console.ReadLine());

            this.LogicContact.CreateExtraLogic(newExtra);
            Console.ReadLine();
        }
    }
}
