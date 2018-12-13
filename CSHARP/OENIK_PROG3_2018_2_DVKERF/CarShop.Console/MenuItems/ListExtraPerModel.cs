// <copyright file="ListExtraPerModel.cs" company="PlaceholderCompany">
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
    /// ListBrand Menu Action
    /// </summary>
    internal class ListExtraPerModel : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListExtraPerModel"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public ListExtraPerModel(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            IEnumerable<object> connections = this.LogicContact.GetExtraModelLogic();
            this.DisplayExtraModel(connections);
            Console.ReadLine();
        }

        private void DisplayExtraModel(IEnumerable<object> connections)
        {
            foreach (var item in connections)
            {
                Console.WriteLine(item);
            }
        }
    }
}
