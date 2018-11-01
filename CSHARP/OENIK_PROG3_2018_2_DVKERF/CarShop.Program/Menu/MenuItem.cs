using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Program.Menu
{
    class MenuItem
    {
        public IMenuAction MenuAction { get; set; }
        public string DisplayName { get; private set; }
        public string Command { get; private set; }


        public MenuItem(string displayname, string command)
        {
            DisplayName = displayname;
            Command = command;
        }

        public void AddMenuAction(IMenuAction action)
        {
            MenuAction = action;
        }
        

    }
}
