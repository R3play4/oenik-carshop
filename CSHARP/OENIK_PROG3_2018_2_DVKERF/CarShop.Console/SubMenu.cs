// <copyright file="SubMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// SubMenu Item will hold the Menu Items that will execute the methods of the .dll Logic
    /// </summary>
    internal class SubMenu : MainMenu
    {
        // this will help the SubMenu to go back to the main Menu
        private bool goBack;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubMenu"/> class.
        /// </summary>
        /// <param name="name">name of the SubMenu</param>
        /// <param name="command">command of the SubMenu</param>
        public SubMenu(string name, string command)
        {
            this.Name = name;
            this.Command = command;
            this.SubMenuItems = new List<MenuItem>();
        }

        /// <summary>
        /// Gets or sets name of the Sub Menu
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets command that selects this SubMenu
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Gets or sets SubMenuItems
        /// </summary>
        public List<MenuItem> SubMenuItems { get; set; }

        /// <summary>
        /// Gets or sets ParrentMenu. This will make it possible to go back to the main menu.
        /// </summary>
        public MainMenu ParrentMenu { get; set; }

        /// <summary>
        /// Displays the MenuItmes in stored in the field SubMenuItems
        /// </summary>
        public override void DisplayMenu()
        {
            Console.Clear();

            // title of the Menu
            Console.WriteLine("----------{0} Sub Menu----------", this.Name);
            foreach (var item in this.SubMenuItems)
            {
                Console.WriteLine("{0} - {1}", item.Command, item.Name);
            }

            Console.WriteLine("B - Go Back to Main Menu");
        }

        /// <summary>
        /// Selects a MenuITtem from the property SubMenuItmes
        /// </summary>
        public override void SelectMenuItem()
        {
            Console.WriteLine("Select a Sub menu item with the relevant command");

            // asks for user input
            string command = Console.ReadLine().ToUpper();

            // selects a MenuItem
            var selected = this.SubMenuItems.Find(itm => itm.Command == command);

            // if command is B the program will go back to the main menu
            if (command == "B")
            {
                this.goBack = true;
                this.ParrentMenu.StartMenu();
            }

            if (selected != null)
            {
                selected.ExecuteMenuAction();
            }
            else if (selected == null && command != "B")
            {
                // If an invalid command was received the method will call itself again.
                Console.WriteLine("Invalid Command, Press Any key to try again!");
                Console.ReadLine();
                this.DisplayMenu();
                this.SelectMenuItem();
            }
        }

        /// <summary>
        /// Menu loop for SubMenu
        /// </summary>
        public void StartSubMenu()
        {
            this.goBack = false;

            while (!goBack)
            {
                this.DisplayMenu();
                this.SelectMenuItem();
            }
        }
    }
}
