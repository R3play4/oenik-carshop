// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Repository;
    using Data;
    using System.Collections;

    /// <summary>
    /// Implements ILogic CRUD operations
    /// </summary>
    public class Logic : ILogic
    {
        /// <summary>
        /// This will enable to communication with the Repository .dll
        /// </summary>
        private IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// </summary>
        public Logic()
        {
            this.SetRepositoryInterface(new Repository());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Alternative constuctor for mocking
        /// </summary>
        /// <param name="repository">IRepository interface</param>
        //public Logic(IRepository repository)
        //{
        //    this.repository = repository;
        //}

        /// <summary>
        /// Sets the Repository property of the class. This will be used for mocking.
        /// </summary>
        /// <param name="intf">Repositary interface</param>
        public void SetRepositoryInterface(IRepository intf)
        {
            this.repository = intf;
        }

        /// <summary>
        /// Gets list of car brands from repo
        /// </summary>
        /// <returns>Enumerable list of car brands that was received from the repository </returns>
        public IEnumerable<car_brands> GetBrandsLogic()
        {
            IEnumerable<car_brands> brands = this.repository.GetBrandsRepo();
            return brands;
        }

        /// <summary>
        /// Gets list of extras from the repo
        /// </summary>
        /// <returns>List of extras from the repo</returns>
        public IEnumerable<extra> GetExtraLogic()
        {
            IEnumerable<extra> extras = this.repository.GetExtraRepo();
            return extras;
        }

        /// <summary>
        /// Gets a list of models from the repo
        /// </summary>
        /// <returns>List of models from the repo</returns>
        public IEnumerable<car_models> GetModelsLogic()
        {
            IEnumerable<car_models> models = this.repository.GetModelsRepo();
            return models;
        }

        public IEnumerable<model_extra_connection> GetConnectionLogic()
        {
            return this.repository.GetExtraConnectionRepo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetExtraModelLogic()
        {
            IEnumerable<car_models> models = this.repository.GetModelsRepo();
            IEnumerable<extra> extras = this.repository.GetExtraRepo();
            IEnumerable<model_extra_connection> connections = this.repository.GetExtraConnectionRepo();

            var result = from con in connections
                         join mod in models on con.model_id equals mod.id
                         join ext in extras on con.extra_id equals ext.id
                         select new { ID = con.id, Model = mod.name, Extra = ext.name };
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetCountryBrandLogic()
        {
            IEnumerable<car_brands> brands = this.repository.GetBrandsRepo();
            IEnumerable<car_models> models = this.repository.GetModelsRepo();

            var result = from br in brands
                         join mod in models on br.id equals mod.brand_id
                         select new { Country = br.country, FullName = br.name + " " + mod.name };

            return result;
        }

        /// <summary>
        /// Calls CreateBrand method of the repository
        /// </summary>
        /// <param name="brand">new brand parameter that was gathered form the user in the Console Layer</param>
        public void CreateBrandLogic(string name, string country, string url, string date, int revenue)
        {

            car_brands newBrand = new car_brands();

            if (name == string.Empty || country == string.Empty || revenue < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                newBrand.name = name;
                newBrand.country = country;
                newBrand.yearly_revenue = revenue;
            }

            newBrand.url = url;

            // erre kéne validálni
            try
            {
                newBrand.founded = DateTime.Parse(date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid Date Format");
            }

            this.repository.CreateBrandRepo(newBrand);
        }

        /// <summary>
        /// Calls CreateModel method of the repository
        /// </summary>
        /// <param name="model">new model parameter. It properties is empty at this point.</param>
        public void CreateModelLogic(int id, string name, string start_date, int engine_size, int horsepower, int price)
        {
            car_models newModel = new car_models();

            if (name == string.Empty || start_date == string.Empty || engine_size < 0 || horsepower < 0 || price < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                newModel.brand_id = id;
                newModel.name = name;
                newModel.engine_size = engine_size;
                newModel.horsepower = horsepower;
                newModel.starting_price = price;
            }

            try
            {
                newModel.production_start = DateTime.Parse(start_date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid Date Format please use YYYY-MM-DD");
            }

            this.repository.CreateModelRepo(newModel);
        }

        public void CreateExtraLogic(extra newExtra)
        {
            this.repository.CreateExtraRepo(newExtra);
        }

        /// <summary>
        /// Calls DeleteBrand method of repository.
        /// </summary>
        /// <param name="name">name of the brand that needs to be deleted</param>
        public void DeleteBrand(string selection)
        {
            IEnumerable<car_brands> brands = this.repository.GetBrandsRepo();

            IEnumerable<int> brand_ids = brands
                .Select(b => b.id);

            if (this.IsStringNumber(selection) && brand_ids.Contains(int.Parse(selection)))
            {
                car_brands toBeDeleted = brands.Where(b => b.id == int.Parse(selection)).First();
                this.repository.DeleteBrandRepo(toBeDeleted);
            }
            else
            {
                if (!this.IsStringNumber(selection))
                {
                    throw new ArgumentException("Invalid id. You have to select number");
                }
                else
                {
                    throw new ArgumentException("Brand cannot be found. Please select another one");
                }
            }

        }

        /// <summary>
        /// Calls DeleteModel method of repository.
        /// </summary>
        /// <param name="name">name of the brand that needs to be deleted</param>
        public void DeleteModel(string selection)
        {
            IEnumerable<car_models> models = this.repository.GetModelsRepo();

            IEnumerable<int> model_ids = models
                .Select(m => m.id);

            if (this.IsStringNumber(selection) && model_ids.Contains(int.Parse(selection)))
            {
                car_models toBeDeleted = models.Where(m => m.id == int.Parse(selection)).First();
                this.repository.DeleteModelRepo(toBeDeleted);
            }
            else
            {
                if (!this.IsStringNumber(selection))
                {
                    throw new ArgumentException("Invalid id. You have to select number");
                }
                else
                {
                    throw new ArgumentException("Conection cannot be found. Please select another one");
                }
            }
        }

        public void DeleteConnection(string selection)
        {
            IEnumerable<model_extra_connection> connections = this.repository.GetExtraConnectionRepo();

            IEnumerable<int> model_ids = connections
                .Select(c => c.id);

            if (this.IsStringNumber(selection) && model_ids.Contains(int.Parse(selection)))
            {
                model_extra_connection toBeDeleted = connections.Where(m => m.id == int.Parse(selection)).First();
                this.repository.DeleteConnectionRepo(toBeDeleted);
            }
            else
            {
                if (!this.IsStringNumber(selection))
                {
                    throw new ArgumentException("Invalid id. You have to select number");
                }
                else
                {
                    throw new ArgumentException("Model cannot be found. Please select another one");
                }
            }
        }

        /// <summary>
        /// Calls DeleteExtra method of repository.
        /// </summary>
        /// <param name="id">id of the extra that needs to be deleted</param>
        public void DeleteExtra(string selection)
        {
            IEnumerable<extra> extras = this.repository.GetExtraRepo();
            IEnumerable<int> extra_ids = extras.Select(x => x.id);

            if (this.IsStringNumber(selection) && extra_ids.Contains(int.Parse(selection)))
            {
                extra toBeDeleted = extras.Where(x => x.id == int.Parse(selection)).First();
                this.repository.DeleteExtraRepo(toBeDeleted);
            }
            else
            {
                if (!this.IsStringNumber(selection))
                {
                    throw new ArgumentException("Invalid id. You have to select number");
                }
                else
                {
                    throw new ArgumentException("Extra cannot be found. Please select another one");
                }
            }
        }

        /// <summary>
        ///  Calls the Repository Method to update the database.
        /// </summary>
        /// <param name="name">updated name </param>
        /// <param name="country">updated country </param>
        /// <param name="founded">updated foundation date</param>
        /// <param name="revenue">updated revenue</param>
        public void UpdateBrandLogic(int id, string name, string country, string founded, string revenue)
        {
            this.repository.UpdateBrandRepo(id, name, country, founded, revenue);
        }

        /// <summary>
        /// Calls the Repository Method to update the database.
        /// </summary>
        /// <param name="selected"> selected model's id </param>
        /// <param name="brand_id"> new model's brand id</param>
        /// <param name="name"> updated name</param>
        /// <param name="productionStart">updated start date time </param>
        /// <param name="engineSizem">updated engine size</param>
        /// <param name="horsePower">updated horsepower</param>
        /// <param name="startingPrice">updated starting price</param>
        public void UpdateModelLogic(int selected, int brand_id, string name, string productionStart, string engineSize, string horsePower, string startingPrice)
        {
            this.repository.UpdateModelRepo(selected, brand_id, name, productionStart, engineSize, horsePower, startingPrice);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selected"></param>
        /// <param name="catname"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="newReuse"></param>
        public void UpdateExtraLogic(int selected, string catname, string name, string price, string newReuse)
        {
            this.repository.UpdateExtraRepo(selected, catname, name, price , newReuse);
        }

        private bool IsStringNumber(string txt)
        {
            bool isNumber = false;

            int i = 0;
            while (i < txt.Length && char.IsNumber(txt[i]))
            {
                i++;
            }

            // if i is >= the length of txt that means all the chars in txt is a number.
            isNumber = i >= txt.Length;

            return isNumber;
        }
    }
}
