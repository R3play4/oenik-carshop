using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Program.Menu
{
    class MenuItem
    {
        public MenuItem(string displayname, string command)
        {
            this.DisplayName = displayname;
            this.Command = command;
        }

        public IMenuAction MenuAction { get; set; }

        public string DisplayName { get; private set; }

        public string Command { get; private set; }

        public void AddMenuAction(IMenuAction action)
        {
            this.MenuAction = action;
        }
    }
}
