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
            car_models model = new car_models();
            model.brand_id = this.SetBrand();
            model.name = this.SetName();
            model.engine_size = this.SetEngineSize();
            model.production_start = this.SetDate(this.SetYear(), this.SetMonth());
            model.starting_price = this.SetStartingPrice();

            this.LogicContact.CreateModelLogic(model);
            Console.ReadLine();
        }

        private int SetBrand()
        {
            IEnumerable<car_brands> brands = this.LogicContact.GetBrandsLogic();

            var brandsAndIds = brands.Select(b => new
            {
                Id = b.id,
                Name = b.name
            });

            foreach (var item in brandsAndIds)
            {
                Console.WriteLine("{0} - {1}",item.Id, item.Name);
            }

            int max = brandsAndIds.Max(b => b.Id);

            Console.WriteLine("Select the ID of the brand");
            int id = int.Parse(Console.ReadLine());

            if (id < 1 || id > max || !this.IsStringNumber(id.ToString()))
            {
                Console.WriteLine("Invalid ID was received. Select a valid Id");
                this.SetBrand();
            }

            return id;
        }

        private string SetName()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            if (name == string.Empty)
            {
                Console.WriteLine("Name cannot be null. Please enter a name");
                this.SetName();
            }

            return name;
        }

        private int SetEngineSize()
        {
            Console.WriteLine("Engine Size:");
            int engineSize = int.Parse(Console.ReadLine());
            return engineSize;
        }

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

        private int SetHorsePower()
        {
            Console.WriteLine("Horsepower:");
            int horsepower = int.Parse(Console.ReadLine());
            return horsepower;
        }

        private int SetStartingPrice()
        {
            Console.WriteLine("Starting Price:");
            int price = int.Parse(Console.ReadLine());

            return price;
        }
    }
}
