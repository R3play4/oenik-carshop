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
            int revenue = int.Parse(Console.ReadLine());

            try
            {
                this.LogicContact.CreateBrandLogic(name, country, url, date, revenue);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Name or Country cannot be null");
                Console.ReadLine();
            }

            //car_brands newBrand = new car_brands();
            //Console.WriteLine("Enter data of the new Brand");
            //newBrand.id = this.SetPrimaryKey();
            //newBrand.name = this.SetName();
            //newBrand.country = this.SetCountry();
            ////newBrand.founded = this.SetDate(this.SetYear(), this.SetMonth());
            //newBrand.url = this.SetURL();
            //newBrand.yearly_revenue = this.SetRevenue();
            //this.LogicContact.CreateBrandLogic(newBrand);
            //Console.ReadLine();
        }

        private int SetPrimaryKey()
        {
            Console.WriteLine("ID:");
            int id = int.Parse(Console.ReadLine());
            return id;
        }

        private string SetName()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            if (name == string.Empty)
            {
                Console.WriteLine("Name cannot be blank. Please enter a name");
                this.SetName();
            }

            return name;
        }

        private string SetCountry()
        {
            Console.WriteLine("Country: ");
            string country = Console.ReadLine();

            if (country == string.Empty)
            {
                Console.WriteLine("Country cannot be blank. Please enter a name");
                this.SetCountry();
            }

            return country;
        }

        /// <summary>
        /// Ask the year that is need to create the new Brand.Cannot be blank
        /// </summary>
        /// <returns>returns the year if it was valid</returns>
        private string SetYear()
        {
            Console.WriteLine("Year:");
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
            Console.WriteLine("Month: ");
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
                Console.WriteLine("Invalid Month was typed. Please type another month");
                this.SetMonth();
            }

            return month;
        }

        private DateTime SetDate(string year, string month)
        {
            return DateTime.Parse(year + "-" + month + "-01");
        }

        private string SetURL()
        {
            Console.WriteLine("URL:");
            string url = Console.ReadLine();
            return url;
        }

        private int SetRevenue()
        {
            Console.WriteLine("Revenue:");
            string revenue = Console.ReadLine();

            if (!this.IsStringNumber(revenue))
            {
                Console.WriteLine("Invakid data type. Please enter a number");
                this.SetRevenue();
            }

            return int.Parse(revenue);
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
