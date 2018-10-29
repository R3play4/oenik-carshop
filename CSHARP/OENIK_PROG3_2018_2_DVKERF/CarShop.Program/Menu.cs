using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Program
{
    
    class Menu
    {
        public static void StartMenu()
        {
            // this will hold the menu command, q - quite , l - list , r - remove,  m - modify , a - add , j - java web interaction
            string command = "_";

            do
            {
                Console.WriteLine("Enter the desired key\nMenu\n----------\nl - list,\nm - modify,\na - add,\nr - remove,\nj - java web interaction,\nq - quite");
                command = Console.ReadLine();
                switch (command)
                {
                    case "l":
                        Console.WriteLine("List is not yet finnished");
                        break;
                    case "m":
                        Console.WriteLine("Modify is not yet finnished");
                        break;
                    case "a":
                        Console.WriteLine("Add New Item is not yet finnished");
                        break;
                    case "r":
                        Console.WriteLine("Remove Menu Item is not yet finnished");
                        break;
                    case "j":
                        Console.WriteLine("Java webinteraction is not yet finnished");
                        break;
                    case "q":
                        Console.WriteLine("Program will Exit");
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
            while (command != "q");
        }
    }
}
