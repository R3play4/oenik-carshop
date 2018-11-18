namespace CarShop.Console.MenuItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// DeleteBrand Menu Action
    /// </summary>
    internal class DeleteBrand : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteBrand"/> class.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="command">command of the item</param>
        public DeleteBrand(string name, string command)
            : base(name, command)
        {
        }

        /// <summary>
        /// Executes the menu's action
        /// </summary>
        public override void ExecuteMenuAction()
        {
            Console.WriteLine("Delete Brand not Ready Yet");
        }
    }
}
