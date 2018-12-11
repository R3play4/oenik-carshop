// <copyright file="CreateBrand.cs" company="PlaceholderCompany">
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
        /// Creates new car_brand based on the user's input, passed it to Logic.
        /// </summary>
        public override void ExecuteMenuAction()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Country:");
            string country = Console.ReadLine();

            Console.WriteLine("URL:");
            string url = Console.ReadLine();

            Console.WriteLine("Founded: YYYY-MM-DD");
            string date = Console.ReadLine();

            Console.WriteLine("Revenue:");
            string revenue = Console.ReadLine();

            try
            {
                this.LogicContact.CreateBrandLogic(name, country, url, date, revenue);
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
    }
}
