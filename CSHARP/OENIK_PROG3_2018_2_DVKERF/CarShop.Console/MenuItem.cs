// <copyright file="MenuItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic;

    /// <summary>
    /// Abstract class. It's children classes will implement the ExecuteMenuAction method whic will be incontact wih the CarShop.Logic.dll class
    /// </summary>
    internal abstract class MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="name">name of the MenuItem</param>
        /// <param name="command">name of the Command</param>
        public MenuItem(string name, string command)
        {
            this.Name = name;
            this.Command = command;
            this.LogicContact = new CarLogic();
        }

        /// <summary>
        /// Gets LogicContact which will be used by children MenuItem-s to call logic methods.
        /// </summary>
        public ICarLogic LogicContact { get; private set; }

        /// <summary>
        /// Gets name of the MenuItem
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets Command of the MenuItem
        /// </summary>
        public string Command { get; private set; }

        /// <summary>
        /// Gets or sets the SubMenu.
        /// </summary>
        public SubMenu SubMenu_ { get; set; }

        /// <summary>
        /// This method will be implemented by the children classes.
        /// </summary>
        public abstract void ExecuteMenuAction();
    }
}
