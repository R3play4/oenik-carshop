using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Program.Menu
{
    class MainMenu
    {
        public MainMenu()
        {
            this.MenuItems = new List<MenuItem>();
            this.ExitMenu = false;
        }

        public bool ExitMenu { get; set; }

        public List<MenuItem> MenuItems { get; set; }

        public void AddMenuItem(MenuItem newMenuItem)
        {
            this.MenuItems.Add(newMenuItem);
        }

        public void DisplayMenu()
        {
            Console.WriteLine("----------CarShop Menu----------");
            foreach (var mi in this.MenuItems)
            {
                Console.WriteLine("{0} - {1}",mi.Command, mi.DisplayName );
            }
        }

        public void SelectMenuItem()
        {
            Console.WriteLine("Press a Button");
            string command = Console.ReadLine();
            MenuItem menuItem = this.MenuItems.Find(x => x.Command == command.ToUpper());

            if (menuItem != null)
            {
                if (menuItem.MenuAction.GetType() == typeof(ExitAction))
                {
                    this.ExitMenu = true;
                }

                menuItem.MenuAction.ExecuteMenuAction();

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Command, please enter another key");
            }
        }

        public void StartMenu()
        {
            while (!this.ExitMenu)
            {
                this.DisplayMenu();
                this.SelectMenuItem();
                Console.ReadLine();
                Console.Clear();
            }
        }

    }
}
