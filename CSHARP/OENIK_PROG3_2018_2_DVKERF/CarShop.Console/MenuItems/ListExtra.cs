﻿namespace CarShop.Console.MenuItems
{
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
            Console.WriteLine("List Extra not Ready Yet");
        }
    }
}
