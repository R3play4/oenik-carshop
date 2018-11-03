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
        /// Builds a Menu with MenuItems and Menu Actions.
        /// </summary>
        public void MenuBuilder()
        {

            // CRUD
            MenuItem createBrand = new MenuItem("Create Brand", "CB");
            createBrand.AddMenuAction(new CreateBrandAction());

            MenuItem createModel = new MenuItem("Create Model", "CM");
            createModel.AddMenuAction(new CreateModelAction());

            MenuItem createExtra = new MenuItem("Create Extra", "CE");
            createExtra.AddMenuAction(new CreateExtraAction());

            MenuItem updateBrand = new MenuItem("Update Brand", "UB");
            updateBrand.AddMenuAction(new UpdateBrandAction());

            MenuItem updateModel = new MenuItem("Update Model", "UM");
            updateModel.AddMenuAction(new UpdateModelAction());

            MenuItem updateExtra = new MenuItem("Update Extra", "UE");
            updateExtra.AddMenuAction(new UpdateExtraAction());

            MenuItem deleteBrand = new MenuItem("Delte Brand", "DB");
            deleteBrand.AddMenuAction(new DeleteBrandAction());

            MenuItem deleteModel = new MenuItem("Delete Model", "DM");
            deleteModel.AddMenuAction(new DeleteModelAction());

            MenuItem deleteExtra = new MenuItem("Delte Extra", "DE");
            deleteExtra.AddMenuAction(new DeleteExtraAction());

            MenuItem listBrand= new MenuItem("List Brand", "LB");
            listBrand.AddMenuAction(new ListBrandAction());

            MenuItem listModel = new MenuItem("List Model", "LM");
            listModel.AddMenuAction(new ListModelAction());

            MenuItem listExtra = new MenuItem("List Extra", "LE");
            listExtra.AddMenuAction(new ListExtraAction());

            // Java
            MenuItem javaEndPoint = new MenuItem("Get Data from Java End Point", "J");
            javaEndPoint.AddMenuAction(new JavaGetDataAction());

            // Non CRUD

            // displays brand+model+country
            MenuItem listBrandsAndModelbyCountry = new MenuItem("List Brands and models by country", "LBM");
            listBrandsAndModelbyCountry.AddMenuAction(new ListBrandsAndModelsPerCountryAction());

            // counts number of extras/ model
            MenuItem listExtraModel = new MenuItem("List Extras per model", "LEM");
            listExtraModel.AddMenuAction(new ListExtraPerModelAction());

            // lists brands + models where the horspower is greater than 200
            MenuItem listMuscle = new MenuItem("List Muscle Cars", "LMC");
            listMuscle.AddMenuAction(new ListMuscleCarsAction());

            MenuItem java = new MenuItem("Get Data From Java Endpoint", "J");
            java.AddMenuAction(new JavaGetDataAction());

            MenuItem exit = new MenuItem("Exit Menu", "E");
            exit.AddMenuAction(new ExitAction());

            this.AddMenuItem(listBrand);
            this.AddMenuItem(listModel);
            this.AddMenuItem(listExtra);
            this.AddMenuItem(listExtraModel);
            this.AddMenuItem(listBrandsAndModelbyCountry);
            this.AddMenuItem(listExtraModel);

            this.AddMenuItem(createBrand);
            this.AddMenuItem(createModel);
            this.AddMenuItem(createExtra);

            this.AddMenuItem(updateBrand);
            this.AddMenuItem(updateModel);
            this.AddMenuItem(updateExtra);

            this.AddMenuItem(deleteBrand);
            this.AddMenuItem(deleteModel);
            this.AddMenuItem(deleteExtra);

            this.AddMenuItem(java);
            this.AddMenuItem(exit);
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
