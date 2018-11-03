// <copyright file="MenuItem.cs" company="PlaceholderCompany">
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
    /// A Main Menu will be a collection of Menu Items.
    /// </summary>
    internal class MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// Constructor
        /// </summary>
        /// <param name="displayname">name that will be displayed in the menu</param>
        /// <param name="command">character that needs to be pressed to invoke the MenuItem</param>
        public MenuItem(string displayname, string command)
        {
            this.DisplayName = displayname;
            this.Command = command;
        }

        /// <summary>
        /// Gets or sets the MenuItem's action. This property determines what actions can be done with a given MenuItem.
        /// </summary>
        public IMenuAction MenuAction { get; set; }

        /// <summary>
        /// Gets the DisplayName.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets the Command which invokes the MenuItem.
        /// </summary>
        public string Command { get; private set; }

        /// <summary>
        /// Adds new IMenuAction interface
        /// </summary>
        /// <param name="action">name of the new action that will be assigend</param>
        public void AddMenuAction(IMenuAction action)
        {
            this.MenuAction = action;
        }
    }
}
