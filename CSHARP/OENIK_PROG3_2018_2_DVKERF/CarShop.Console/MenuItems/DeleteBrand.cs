// <copyright file="DeleteBrand.cs" company="PlaceholderCompany">
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
    /// DeleteBrand Menu Action
    /// </summary>
    internal class DeleteBrand : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteBrand"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public DeleteBrand(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            int id = this.ChooseBrand();
            this.LogicContact.DeleteBrand(id);
            Console.ReadLine();
        }

        /// <summary>
        /// Lists brand names and ids. User can pick one based on the id.
        /// </summary>
        /// <returns>returns the id of the selected brand </returns>
        private int ChooseBrand()
        {
            IEnumerable<car_brands> brands = this.LogicContact.GetBrandsLogic();

            var brand_ids_names = brands.Select(x => new
            {
                ID = x.id,
                NAME = x.name
            });

            int max_id = brands.Max(i => i.id);

            foreach (var brand in brand_ids_names)
            {
                Console.WriteLine("{0} - {1}", brand.ID, brand.NAME);
            }

            Console.WriteLine("Select an ID");
            int selection = int.Parse(Console.ReadLine());

            if (selection < 1 || selection > max_id)
            {
                Console.WriteLine("Invalid ID was picked. Select another one");
                this.ChooseBrand();
            }

            return selection;
        }
    }
}
