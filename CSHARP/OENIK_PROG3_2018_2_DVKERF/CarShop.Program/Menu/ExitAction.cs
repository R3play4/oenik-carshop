using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Program.Menu
{
    class ExitAction : IMenuAction
    {
        public void ExecuteMenuAction()
        {
            Console.Clear();
            Console.WriteLine("Press a button to close the application");
        }
    }
}
