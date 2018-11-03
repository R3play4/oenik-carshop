// <copyright file="ExitAction.cs" company="PlaceholderCompany">
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
    /// This is responsible for exiting the application's menu.
    /// </summary>
    internal class ExitAction : IMenuAction
    {
        /// <summary>
        /// If this method is called the Main Menu will change ExitMenu property to true.
        /// </summary>
        public void ExecuteMenuAction()
        {
            Console.Clear();
            Console.WriteLine("Press a button to close the application");
        }
    }
}
