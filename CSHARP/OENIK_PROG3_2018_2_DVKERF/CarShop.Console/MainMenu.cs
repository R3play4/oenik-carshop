// <copyright file="MainMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Main Menu class is responsible for displaying and selecting Menu Items.
    /// </summary>
    internal class MainMenu
    {
        /// <summary>
        /// This is used by the StartMenu method. If true the Method will break.
        /// </summary>
        private bool exit;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu"/> class.
        /// Main Menu Konstuktor
        /// </summary>
        public MainMenu()
        {
            this.SubMenus = new List<SubMenu>();
        }

        /// <summary>
        /// Gets or sets property SubMenu
        /// </summary>
        public List<SubMenu> SubMenus { get; set; }

        /// <summary>
        /// Displays all of the Sub Menu-s of the Main Menu
        /// </summary>
        public virtual void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("----------Car Shop Main Menu----------");
            foreach (var item in this.SubMenus)
            {
                Console.WriteLine("{0} - {1}", item.Command, item.Name);
            }

            Console.WriteLine("E - Exit Menu");
        }

        /// <summary>
        /// Selects a Sub Menu from the Sub Menus.
        /// </summary>
        public virtual void SelectMenuItem()
        {
            Console.WriteLine("Select a Menu by pressing the relevant command");

            // gets input from the user
            string command = Console.ReadLine().ToUpper();

            // selects a SubMenu
            var selected = this.SubMenus.Find(itm => itm.Command == command);

            // if the command is E the private field "exit" will be set to true, this will break the StartMenu() loop
            if (command == "E")
            {
                this.exit = true;
                Console.WriteLine("Exiting application.....");
                Console.ReadLine();
            }

            // checks if a valid Sub Menu was selected
            if (selected != null)
            {
                // sets the SubMenu's Parrent Item to 'this'. This will help the SubMenu to go Back to the Main Menu.
                selected.ParrentMenu = this;
                selected.StartSubMenu();
            }
            else if (selected == null && command != "E")
            {
                // If an invalid command was received the method will call itself again.
                Console.WriteLine("Invalid Command, Press Any key to try again!");
                Console.ReadLine();
                this.DisplayMenu();
                this.SelectMenuItem();
            }
        }

        /// <summary>
        /// Menu Loop. It will display the menu and ask for selection until the private field exit is not set to true by using the E command
        /// </summary>
        public void StartMenu()
        {
            this.exit = false;

            while (!this.exit)
            {
                this.DisplayMenu();
                this.SelectMenuItem();
            }
        }
    }
}
