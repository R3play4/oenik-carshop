// <copyright file="DeleteModel.cs" company="PlaceholderCompany">
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
    /// DeleteModel Menu Action
    /// </summary>
    internal class DeleteModel : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteModel"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public DeleteModel(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            this.DisplayOptions();
            Console.WriteLine("Select the id of the Model that you would like to delete");
            string selection = Console.ReadLine();

            try
            {
                this.LogicContact.DeleteModel(selection);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private void DisplayOptions()
        {
            IEnumerable<CarModels> models = this.LogicContact.ListModelLogic();

            foreach (var model in models)
            {
                Console.WriteLine("{0} - {1}", model.id, model.name);
            }
        }
    }
}
