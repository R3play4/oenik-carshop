// <copyright file="CreateModel.cs" company="PlaceholderCompany">
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
    using Logic;

    /// <summary>
    /// Create Model Menu Action
    /// </summary>
    internal class CreateModel : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateModel"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public CreateModel(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            this.DisplayBrands();
            Console.WriteLine("Brand Id:");
            string brandId = Console.ReadLine();

            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Start Date:YYYY-MM-DD");
            string start = Console.ReadLine();

            Console.WriteLine("Engine Size:");
            string engine = Console.ReadLine();

            Console.WriteLine("Horsepower:");
            string horsepower = Console.ReadLine();

            Console.WriteLine("Starting Price:");
            string price = Console.ReadLine();

            try
            {
                this.LogicContact.CreateModelLogic(brandId, name, start, engine, horsepower, price);
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

            Console.ReadLine();
        }

        private void DisplayBrands()
        {
            IEnumerable<car_brands> brands = this.LogicContact.GetBrandsLogic();

            foreach (var brand in brands)
            {
                Console.WriteLine("{0} - {1}", brand.id, brand.name);
            }
        }
    }
}
