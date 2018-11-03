// <copyright file="MainMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Program.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// MainMenu will display the Menu Options.
    /// </summary>
    internal class MainMenu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu"/> class.
        /// </summary>
        public MainMenu()
        {
            this.MenuItems = new List<MenuItem>();
            this.ExitMenu = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Main Menu can exit. False by default.
        /// </summary>
        public bool ExitMenu { get; set; }

        /// <summary>
        /// Gets or sets Menu Items. This holdes the available menu options.
        /// </summary>
        public List<MenuItem> MenuItems { get; set; }

        /// <summary>
        /// New Menu items can be added to the already existing ones.
        /// </summary>
        /// <param name="newMenuItem">The new item to be added to the list</param>
        public void AddMenuItem(MenuItem newMenuItem)
        {
            this.MenuItems.Add(newMenuItem);
        }

        /// <summary>
        /// Displays the MenuItem's display name and command that are stored in the MenuItmes property.
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine("----------CarShop Menu----------");
            foreach (var mi in this.MenuItems)
            {
                Console.WriteLine("{0} - {1}", mi.Command, mi.DisplayName);
            }
        }

        /// <summary>
        /// Selects MenuItem based on user input. Checks for valid input.
        /// </summary>
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

        /// <summary>
        /// Main Menu loop. Displays the menu. After that it asks for selection. This mehtod will run until the ExitMenu property is set to true.
        /// </summary>
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
