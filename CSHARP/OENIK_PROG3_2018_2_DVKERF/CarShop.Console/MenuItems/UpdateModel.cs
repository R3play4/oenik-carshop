// <copyright file="UpdateModel.cs" company="PlaceholderCompany">
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
            int selectedModel = this.ChooseModel();

            // Setting new values. At this point everything is stored string values.
            Console.WriteLine();
            Console.WriteLine("Brand:");
            int newBrand = SetBrand();

            Console.WriteLine("Name:");
            string newName = Console.ReadLine();

            Console.WriteLine("Start Date of production:");
            string newStartDate = Console.ReadLine();

            Console.WriteLine("Engine Size:");
            string newEngineSize = Console.ReadLine();

            Console.WriteLine("HorsePower:");
            string newHorsePower = Console.ReadLine();

            Console.WriteLine("Starting Price:");
            string newStartingPrice = Console.ReadLine();

            this.LogicContact.UpdateModelLogic(selectedModel, newBrand, newName, newStartDate, newEngineSize, newHorsePower, newStartingPrice);

        }

        private int SetBrand()
        {
            IEnumerable<car_brands> brands = this.LogicContact.GetBrandsLogic();

            var brandsAndIds = brands.Select(b => new
            {
                Id = b.id,
                Name = b.name
            });

            foreach (var item in brandsAndIds)
            {
                Console.WriteLine("{0} - {1}", item.Id, item.Name);
            }

            int max = brandsAndIds.Max(b => b.Id);

            Console.WriteLine("Select the ID of the brand");
            string idStr = Console.ReadLine();

            if (idStr != string.Empty && int.Parse(idStr) < 1 && int.Parse(idStr) <= max)
            {
                return int.Parse(Console.ReadLine());
            }
            else
            {
                return 0;
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
