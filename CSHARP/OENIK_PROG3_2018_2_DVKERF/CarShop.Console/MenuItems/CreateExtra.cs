// <copyright file="CreateExtra.cs" company="PlaceholderCompany">
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

            Console.WriteLine("Category:");
            string categoryName = Console.ReadLine();

            Console.WriteLine("Name:");
            string extraName = Console.ReadLine();

            Console.WriteLine("Price:");
            string price = Console.ReadLine();

            Console.WriteLine("Color:");
            string color = Console.ReadLine();

            Console.WriteLine("Reuseable: ");
            string reuseable = Console.ReadLine();

            try
            {
                this.LogicContact.CreateExtraLogic(categoryName, extraName, color, price, reuseable);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
