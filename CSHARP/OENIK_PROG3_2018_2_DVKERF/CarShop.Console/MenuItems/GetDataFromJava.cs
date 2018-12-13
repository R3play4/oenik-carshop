// <copyright file="GetDataFromJava.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Console.MenuItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Data;

    /// <summary>
    /// Creates Object that gets Data from Java Endpoint.
    /// </summary>
    internal class GetDataFromJava : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDataFromJava"/> class.
        /// </summary>
        /// <param name="name">name of the menu</param>
        /// <param name="command">command that invokes the menu</param>
        public GetDataFromJava(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes menu action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            IEnumerable<CarData> cars = this.LogicContact.GetFullNamePricesLogic();
            try
            {
                CarData selected = this.SelectCar(cars.ToList());
                string carName = selected.FullName;
                string price = selected.Price.ToString();
                XDocument data = XDocument.Load("http://localhost:8080/OENIK_PROG3_2018_2_DVKERF_war_exploded/RandomPriceGenerator?carname=" + carName + "&" + "price=" + price);

                var names = data.Root.Elements("cardata").Elements("name").ToList();
                var prices = data.Root.Elements("cardata").Elements("price").ToList();

                for (int i = 0; i < names.Count(); i++)
                {
                    Console.WriteLine("{0} - {1}", names[i].Value, prices[i].Value);
                }

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private void DisplayOptions(IEnumerable<CarData> cars)
        {
            foreach (var car in cars)
            {
                System.Console.WriteLine("{0} - {1} - {2}", car.Id, car.FullName, car.Price);
            }
        }

        private CarData SelectCar(List<CarData> cars)
        {
            this.DisplayOptions(cars);
            int max_id = cars.Max(i => i.Id);

            Console.WriteLine("Select the id of the car for which you would like to get quotes");
            int selection;

            if (int.TryParse(Console.ReadLine(), out selection) && selection <= max_id)
            {
                return cars[selection - 1];
            }
            else
            {
                throw new Exception("Incorrect id was selected");
            }
        }
    }
}
