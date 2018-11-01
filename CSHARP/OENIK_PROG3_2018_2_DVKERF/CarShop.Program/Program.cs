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

            MenuItem update = new Menu.MenuItem("Update Item", "U");
            update.AddMenuAction(new UpdateAction());

            MenuItem delete = new MenuItem("Delete Item", "D");
            delete.AddMenuAction(new DeleteAction());

            MenuItem list = new MenuItem("List Item", "L");
            list.AddMenuAction(new ListAction());

            menu.AddMenuItem(list);
            menu.AddMenuItem(create);
            menu.AddMenuItem(update);
            menu.AddMenuItem(exit);

            menu.StartMenu();
        }
    }
}
