// <copyright file="DeleteExtra.cs" company="PlaceholderCompany">
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
    /// DeleteExtra Menu Action
    /// </summary>
    internal class DeleteExtra : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteExtra"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public DeleteExtra(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            Console.WriteLine("Enter the id of the extra you would like to delete");
            int id = this.ChooseExtra();

            this.LogicContact.DeleteExtra(id);
            Console.ReadLine();
        }

        private int ChooseExtra()
        {
            IEnumerable<extra> extras = this.LogicContact.GetExtraLogic();

            var brand_ids_names = extras.Select(x => new
            {
                ID = x.id,
                NAME = x.name
            });

            int max_id = extras.Max(i => i.id);

            foreach (var brand in brand_ids_names)
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
