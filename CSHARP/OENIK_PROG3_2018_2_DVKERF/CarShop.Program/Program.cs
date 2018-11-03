// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Program.Menu;

    /// <summary>
    /// Main Class. Includes Entry point (Main method)
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point -> Main Method
        /// </summary>
        /// <param name="args">arguments</param>
        internal static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.MenuBuilder();
            menu.StartMenu();
        }
    }
}
