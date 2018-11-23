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

            // year of foundation
            string year = this.SetYear();

            // month of foundation
            string month = this.SetMonth();

            // day of foundation will automatically set ti 01. 
            string day = "01";

            // sets the date string that will be parsed into DateTime Type.
            string date = year + "-" + month + "-" + day;
            newBrand.founded = DateTime.Parse(date);

            // yearly revenue
            Console.WriteLine("What was last year's revenue:");
            newBrand.yearly_revenue = int.Parse(Console.ReadLine());

            // calls Logic Method
            this.LogicContact.CreateBrandLogic(newBrand);
            Console.ReadLine();
        }

        /// <summary>
        /// Ask the year that is need to create the new Brand.Cannot be blank
        /// </summary>
        /// <returns>returns the year if it was valid</returns>
        private string SetYear()
        {
            Console.WriteLine("Set the year of the foundation (cannot be blank)");
            string year = Console.ReadLine();

            // checks if valid year was typed. Valid year is a number and older than or equals to the curent year (2018 in this case)
            if (this.IsStringNumber(year) && int.Parse(year) <= DateTime.Now.Year)
            {
                return year;
            }
            else
            {
                Console.WriteLine("Invalid year was typed, please type another year");
                this.SetYear();
            }

            return year;
        }

        /// <summary>
        /// Sets the month the foundatin. If no month was given than it will be 01 atumatically.
        /// </summary>
        /// <returns>return month if valid or 01 if no month was provided. </returns>
        private string SetMonth()
        {
            Console.WriteLine("Set the month of the foundation. (If unknown just press Enter)");
            string month = Console.ReadLine();

            if (this.IsStringNumber(month) && month.Length == 2 && int.Parse(month) <= 12)
            {
                return month;
            }
            else if (month == string.Empty)
            {
                month = "01";
                return month;
            }
            else
            {
                Console.WriteLine("Invalid Month was typed Please type another month");
                this.SetMonth();
            }

            return month;
        }

        private bool IsStringNumber(string txt)
        {
            bool isNumber = false;

            int i = 0;
            while (i < txt.Length && char.IsNumber(txt[i]))
            {
                i++;
            }

            // if i is >= the length of txt that means all the chars in txt is a number. 
            isNumber = i >= txt.Length;

            return isNumber;
        }
    }
}
