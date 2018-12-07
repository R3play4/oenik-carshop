// <copyright file="ListBrandsModelsPerCountry.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Console.MenuItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// List How many brands a country have.
    /// </summary>
    internal class ListBrandsModelsPerCountry : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListBrandsModelsPerCountry"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public ListBrandsModelsPerCountry(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            IEnumerable<object> countryBrands = this.LogicContact.GetCountryBrandLogic();
            Display(countryBrands);
            Console.ReadLine();
        }

        private void Display(IEnumerable<object> table)
        {
            foreach (var item in table)
            {
                Console.WriteLine(item);
            }
        }
    }
}
