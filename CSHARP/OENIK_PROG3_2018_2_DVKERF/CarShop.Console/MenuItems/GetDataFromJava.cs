// <copyright file="GetDataFromJava.cs" company="PlaceholderCompany">
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
    using System.Xml.Linq;

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
                CarData test = this.SelectCar(cars.ToList());
                Console.WriteLine(test.FullName);
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
