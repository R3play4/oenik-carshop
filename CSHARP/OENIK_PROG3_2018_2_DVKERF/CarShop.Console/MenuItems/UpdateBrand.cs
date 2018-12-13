// <copyright file="UpdateBrand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Console.MenuItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Logic;
    using Data;

    /// <summary>
    /// ListBrand Menu Action
    /// </summary>
    internal class UpdateBrand : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBrand"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public UpdateBrand(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            this.DisplayBrands();
            Console.WriteLine("Select the ID of the Brand that you would like to update");
            string selectedBrandID = Console.ReadLine();

            Console.WriteLine("Enter a new value or hit enter");

            Console.WriteLine("Name:");
            string newName = Console.ReadLine();

            Console.WriteLine("Country:");
            string newCountry = Console.ReadLine();

            Console.WriteLine("Date:");
            string newDate = Console.ReadLine();

            Console.WriteLine("Reveneu: ");
            string newRevenue = Console.ReadLine();

            try
            {
                this.LogicContact.UpdateBrandLogic(selectedBrandID, newName, newCountry, newDate, newRevenue);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            catch (InvalidParameterException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private void DisplayBrands()
        {
            IEnumerable<CarBrands> brands = this.LogicContact.ListBrandLogic();

            foreach (var brand in brands)
            {
                Console.WriteLine("{0} - {1}", brand.Id, brand.Name);
            }
        }
    }
}
