namespace CarShop.Console.MenuItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;

    internal class ListFullNamesAndPrices : MenuItem
    {
        public ListFullNamesAndPrices(string name, string command) 
            : base(name, command)
        {
        }

        public override void ExecuteMenuAction()
        {
            IEnumerable<CarData> cars = this.LogicContact.GetFullNamePricesLogic();
            this.DisplayOptions(cars);
            Console.ReadLine();
        }

        private void DisplayOptions(IEnumerable<CarData> cars)
        {
            foreach (var car in cars)
            {
                System.Console.WriteLine("{0} - {1} - {2}", car.Id, car.FullName, car.Price);
            }
        }
    }
}
