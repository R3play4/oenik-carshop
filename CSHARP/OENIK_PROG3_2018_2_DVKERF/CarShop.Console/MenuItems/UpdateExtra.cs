// <copyright file="UpdateExtra.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Console.MenuItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;

    /// <summary>
    /// UpdateExtra Menu Action
    /// </summary>
    internal class UpdateExtra : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateExtra"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public UpdateExtra(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            this.DisplayExtra();
            Console.WriteLine("Select the ID of the Extra that you would like to update");
            string extraSelected = Console.ReadLine();

            Console.WriteLine("Enter a new value or hit enter");

            Console.WriteLine("Category Name");
            string newCategory = Console.ReadLine();

            Console.WriteLine("Name");
            string newName = Console.ReadLine();

            Console.WriteLine("Price:");
            string newPrice = Console.ReadLine();

            Console.WriteLine("Reuseable:");
            string newReuse = Console.ReadLine();

            this.LogicContact.UpdateExtraLogic(extraSelected, newCategory, newName, newPrice, newReuse);

            Console.ReadLine();
        }

        private void DisplayExtra()
        {
            IEnumerable<extra> extras = this.LogicContact.ListExtraLogic();

            foreach (var extra in extras)
            {
                Console.WriteLine(extra);
            }
        }
    }
}
