using CarShop.Program.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Program
{
    class Program
    {
        static void Main(string[] args)
        {

            MainMenu menu = new MainMenu();

            MenuItem create = new MenuItem("Create Item", "C");
            create.AddMenuAction(new CreateAction());

            MenuItem exit = new Menu.MenuItem("Exit Program", "E");
            exit.AddMenuAction(new ExitAction());

            menu.AddMenuItem(create);
            menu.AddMenuItem(exit);

            menu.StartMenu();
        }
    }
}
