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
            this.DisplayOptions();
            Console.WriteLine("Select the ID of the Brand you would like to delete");
            string selection = Console.ReadLine();

            try
            {
                this.LogicContact.DeleteBrand(selection);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private void DisplayOptions()
        {
            IEnumerable<car_brands> brands = this.LogicContact.GetBrandsLogic();

            foreach (var brand in brands)
            {
                Console.WriteLine("{0} - {1}", brand.id, brand.name);
            }
        }

        //private int ChooseBrand()
        //{
        //    IEnumerable<car_brands> brands = this.LogicContact.GetBrandsLogic();

        //    var brand_ids_names = brands.Select(x => new
        //    {
        //        ID = x.id,
        //        NAME = x.name
        //    });

        //    int max_id = brands.Max(i => i.id);

        //    foreach (var brand in brand_ids_names)
        //    {
        //        Console.WriteLine("{0} - {1}", brand.ID, brand.NAME);
        //    }

        //    Console.WriteLine("Select an ID");
        //    string selection = Console.ReadLine();

        //    while (!this.IsStringNumber(selection) || int.Parse(selection) < 1 || int.Parse(selection) > max_id)
        //    {
        //        Console.WriteLine("Invalid ID, Choose again");
        //        selection = Console.ReadLine();
        //    }

        //    return int.Parse(selection);
        //}
    }
}
