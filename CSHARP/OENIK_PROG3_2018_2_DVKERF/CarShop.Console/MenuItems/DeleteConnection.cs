// <copyright file="DeleteConnection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Console.MenuItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;

    /// <summary>
    /// Menu for deleting existing Extra Model connections
    /// </summary>
    internal class DeleteConnection : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteConnection"/> class.
        /// </summary>
        /// <param name="name"> name of the menu </param>
        /// <param name="command">command that calls this menu </param>
        public DeleteConnection(string name, string command) 
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            this.DisplayOptions();
            Console.WriteLine("Select the ID of the connection you would like to delete");
            string selection = Console.ReadLine();

            try
            {
                this.LogicContact.DeleteConnection(selection);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private void DisplayOptions()
        {
            IEnumerable<object> connections = this.LogicContact.GetExtraModelLogic();

            foreach (var con in connections)
            {
                Console.WriteLine(con);
            }
        }

        private int ChooseConnection()
        {
            IEnumerable<object> modelsExtra = this.LogicContact.GetExtraModelLogic();

            foreach (var item in modelsExtra)
            {
                Console.WriteLine(item);
            }

            int selected = 0;
            Console.WriteLine("Select the id of the connection that you would like to delete");

            try
            {
                selected = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return selected;
        }
    }
}
