using CarShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Console.MenuItems
{
    internal class DeleteConnection : MenuItem
    {
        public DeleteConnection(string name, string command) 
            : base(name, command)
        {
        }

        // Ez majd egy groupolt megjelnitéssel fog törölni.
        public override void ExecuteMenuAction()
        {
            throw new NotImplementedException();
        }
    }
}
