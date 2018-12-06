// <copyright file="DeleteModel.cs" company="PlaceholderCompany">
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
            Console.WriteLine("Enter the id of the model you would like to delete.");
            int id = this.ChooseModel();
            this.LogicContact.DeleteModel(id);
            Console.ReadLine();
        }

        private int ChooseModel()
        {
            IEnumerable<car_models> models = this.LogicContact.GetModelsLogic();

            var model_ids_names = models.Select(x => new
            {
                ID = x.id,
                NAME = x.name
            });

            int max_id = models.Max(i => i.id);

            foreach (var model in model_ids_names)
            {
                Console.WriteLine("{0} - {1}", model.ID, model.NAME);
            }

            Console.WriteLine("Select an ID");
            int selection = int.Parse(Console.ReadLine());

            if (selection < 1 || selection > max_id)
            {
                Console.WriteLine("Invalid ID was picked. Select another one");
                this.ChooseModel();
            }

            return selection;
        }
    }
}
