// <copyright file="ListModel.cs" company="PlaceholderCompany">
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
    internal class ListModel : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListModel"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public ListModel(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            IEnumerable<car_models> models = this.LogicContact.ListModelLogic();
            this.DisplayModels(models);
            Console.ReadLine();
        }

        /// <summary>
        /// Gets the models from the logic, and displays it.
        /// </summary>
        /// <param name="models">models that was received from the logic layer and neds to be displayed</param>
        private void DisplayModels(IEnumerable<car_models> models)
        {
            var result = models.Select(b => new
            {
                Id = b.id,
                Brand_Id = b.brand_id,
                Name = b.name,
                Engine_Size = b.engine_size,
                Horspower = b.horsepower,
                Start_Date = b.production_start.ToString().Substring(0, 10)
            });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
