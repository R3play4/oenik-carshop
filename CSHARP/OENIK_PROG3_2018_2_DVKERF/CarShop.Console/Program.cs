// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CarShop.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MenuItems;

    /// <summary>
    /// Main Class. Includes Entry point (Main method)
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point -> Main Method
        /// </summary>
        /// <param name="args">arguments</param>
        internal static void Main(/*string[] args*/)
        {
            // Initiating Menu
            MainMenu menu = new MainMenu();

            SubMenu list = new SubMenu("List", "L");
            list.SubMenuItems.Add(new ListBrand("List Brand", "LB"));
            list.SubMenuItems.Add(new ListModel("List Model", "LM"));
            list.SubMenuItems.Add(new ListExtraPerModel("List Extra Per Model", "LEM"));
            list.SubMenuItems.Add(new ListExtra("List Extra", "LE"));
            list.SubMenuItems.Add(new ListBrandsModelsPerCountry("List Brands and Models Per Country", "LBM"));
            list.SubMenuItems.Add(new GetDataFromJava("List data from Java Endpoint", "J"));
            menu.SubMenus.Add(list);

            SubMenu create = new SubMenu("Create", "C");
            create.SubMenuItems.Add(new CreateBrand("Create Brand", "CB"));
            create.SubMenuItems.Add(new CreateModel("Create Model", "CM"));
            create.SubMenuItems.Add(new CreateExtra("Create Extra", "CE"));
            menu.SubMenus.Add(create);

            SubMenu update = new SubMenu("Update", "U");
            update.SubMenuItems.Add(new UpdateBrand("Update Brand", "UB"));
            update.SubMenuItems.Add(new UpdateModel("Update Model", "UM"));
            update.SubMenuItems.Add(new UpdateExtra("Update Extra", "UE"));
            menu.SubMenus.Add(update);

            SubMenu delete = new SubMenu("Delete", "D");
            delete.SubMenuItems.Add(new DeleteBrand("Delete Brand", "DB"));
            delete.SubMenuItems.Add(new DeleteModel("Delete Model", "DM"));
            delete.SubMenuItems.Add(new DeleteExtra("Delete Extra", "DE"));
            delete.SubMenuItems.Add(new DeleteConnection("Delete Extra - Model connection", "DEM"));

            menu.SubMenus.Add(delete);

            menu.StartMenu();
        }
    }
}
