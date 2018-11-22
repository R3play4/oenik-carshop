// <copyright file="CreateBrand.cs" company="PlaceholderCompany">
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
    /// Create Brand Menu Action
    /// </summary>
    internal class CreateBrand : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBrand"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public CreateBrand(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            Console.WriteLine("Enter the parameters of the new brand:");

            car_brands newBrand = new car_brands();

            // name property
            Console.WriteLine("Name:");
            newBrand.name = Console.ReadLine();

            // country property
            Console.WriteLine("Country:");
            newBrand.country = Console.ReadLine();

            // founded
            Console.WriteLine("Date of foundation in the format of yyyy-MM-dd:");
            string founded = Console.ReadLine();
            newBrand.founded = DateTime.Parse(founded);

            // yearly revenue
            Console.WriteLine("What was last year's revenue:");
            newBrand.yearly_revenue = int.Parse(Console.ReadLine());

            // calls Logic Method
            this.LogicContact.CreateBrandLogic(newBrand);
            Console.ReadLine();
        }
    }
}
