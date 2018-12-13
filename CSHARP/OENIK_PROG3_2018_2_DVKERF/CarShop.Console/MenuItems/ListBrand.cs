﻿// <copyright file="ListBrand.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// ListBrand Menu Action
    /// </summary>
    internal class ListBrand : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListBrand"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public ListBrand(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            IEnumerable<CarBrands> brands = this.LogicContact.ListBrandLogic();
            this.DisplayBrands(brands);
            Console.ReadLine();
        }

        /// <summary>
        /// Gets the brands from the logic, and displays it.
        /// </summary>
        /// <param name="brands">brands that was received from the logic layer and neds to be displayed</param>
        private void DisplayBrands(IEnumerable<CarBrands> brands)
        {
            var result = brands.Select(b => new
            {
                Id = b.Id,
                Name = b.Name,
                Country = b.Country,
                Founded = b.Founded.ToString().Substring(0, 10), // cuts of HH:MM:mm
                Revenue = b.YearlyRevenue
            });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
