// <copyright file="ListExtra.cs" company="PlaceholderCompany">
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
    /// ListBrand Menu Action
    /// </summary>
    internal class ListExtra : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListExtra"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public ListExtra(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            IEnumerable<extra> extras = this.LogicContact.GetExtraLogic();
            this.DisplayExtras(extras);
            Console.ReadLine();
        }

        private void DisplayExtras(IEnumerable<extra> extras)
        {
            var result = extras.Select(b => new
            {
                Id = b.id,
                Name = b.name,
                Price = b.price,
                Color = b.color
            });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
