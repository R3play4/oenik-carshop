// <copyright file="UpdateExtra.cs" company="PlaceholderCompany">
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
            int selected = this.ChooseExtra();

            //Set new values
            Console.WriteLine("Category Name");
            string newCategory = Console.ReadLine();

            Console.WriteLine("Name");
            string newName = Console.ReadLine();

            Console.WriteLine("Price:");
            string newPrice = Console.ReadLine();

            Console.WriteLine("Reuseable:");
            string newReuse = Console.ReadLine();

            this.LogicContact.UpdateExtraLogic(selected, newCategory, newName, newPrice, newReuse);

            Console.ReadLine();
        }

        private int ChooseExtra()
        {
            IEnumerable<extra> models = this.LogicContact.GetExtraLogic();

            var extra_ids_names = models.Select(x => new
            {
                ID = x.id,
                NAME = x.name
            });

            int max_id = models.Max(i => i.id);

            foreach (var brand in extra_ids_names)
            {
                Console.WriteLine("{0} - {1}", brand.ID, brand.NAME);
            }

            Console.WriteLine("Select an ID");
            int selection = int.Parse(Console.ReadLine());

            if (selection < 1 || selection > max_id)
            {
                Console.WriteLine("Invalid ID was picked. Select another one");
                this.ChooseExtra();
            }

            return selection;
        }
    }
}
