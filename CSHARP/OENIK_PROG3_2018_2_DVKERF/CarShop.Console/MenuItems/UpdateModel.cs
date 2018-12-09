// <copyright file="UpdateModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Console.MenuItems
{
    using Data;
    using Logic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// UpdateExtra Menu Action
    /// </summary>
    internal class UpdateModel : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateModel"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public UpdateModel(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            this.DisplayModels();
            Console.WriteLine("Select the id of the model you would like to update");
            string id = Console.ReadLine();

            Console.WriteLine("Enter a new value or hit enter");

            Console.WriteLine("Name:");
            string newName = Console.ReadLine();

            Console.WriteLine("Start Date:");
            string startDate = Console.ReadLine();

            Console.WriteLine("Engine size:");
            string engineSize = Console.ReadLine();

            Console.WriteLine("Horsepower:");
            string horsePower = Console.ReadLine();

            Console.WriteLine("Starting Price");
            string startPrice = Console.ReadLine();

            try
            {
                this.LogicContact.UpdateModelLogic(id, newName, startDate, engineSize, horsePower, startPrice);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            catch (InvalidDateFormatException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private void DisplayModels()
        {
            IEnumerable<car_models> models = this.LogicContact.GetModelsLogic();

            foreach (var model in models)
            {
                Console.WriteLine("{0} - {1}", model.id, model.name);
            }
        }

        private void DisplayBrand()
        {
            IEnumerable<car_brands> brands = this.LogicContact.GetBrandsLogic();

            foreach (var item in brands)
            {
                Console.WriteLine("{0} - {1}", item.id, item.name);
            }
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

            foreach (var brand in model_ids_names)
            {
                Console.WriteLine("{0} - {1}", brand.ID, brand.NAME);
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
