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
        public void CreateBrandLogic(string name, string country, string url, string date, string revenue)
        {
            car_brands newBrand = new car_brands();
            int newRevenue = this.SetIntValue(revenue);
            DateTime newDate = this.SetDate(date);

            if (name == string.Empty || country == string.Empty || newDate == default(DateTime) || newRevenue <= 0)
            {
                throw new ArgumentException("Invalid values. Brand cannot be created");
            }
            else
            {
                newBrand.name = name;
                newBrand.country = country;
                newBrand.url = url;
                newBrand.founded = newDate;
                newBrand.yearly_revenue = newRevenue;
                this.repository.CreateBrandRepo(newBrand);
            }

            //car_brands newBrand = new car_brands();

            //if (name == string.Empty || country == string.Empty || revenue < 0)
            //{
            //    throw new ArgumentException();
            //}
            //else
            //{
            //    newBrand.name = name;
            //    newBrand.country = country;
            //    newBrand.yearly_revenue = revenue;
            //}

            //newBrand.url = url;

            //// erre kéne validálni
            //try
            //{
            //    newBrand.founded = DateTime.Parse(date);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine("Invalid Date Format");
            //}

            //this.repository.CreateBrandRepo(newBrand);
        }

        /// <summary>
        /// Calls CreateModel method of the repository
        /// </summary>
        /// <param name="model">new model parameter. It properties is empty at this point.</param>
        public void CreateModelLogic(string brandId, string name, string start_date, string engine_size, string horsepower, string price)
        {
            car_models newModel = new car_models();
            int newBrandId;
            DateTime newDate = this.SetDate(start_date);
            int newEngine = this.SetIntValue(engine_size);
            int newHorseP = this.SetIntValue(horsepower);
            int newPrice = this.SetIntValue(price);

            if (int.TryParse(brandId, out newBrandId) && this.BrandExists(newBrandId) && newDate != default(DateTime) && newEngine > 0 && newHorseP > 0 && newPrice > 0 && name != string.Empty)
            {
                newModel.name = name;
                newModel.brand_id = newBrandId;
                newModel.production_start = newDate;
                newModel.engine_size = newEngine;
                newModel.horsepower = newHorseP;
                newModel.starting_price = newPrice;
                this.repository.CreateModelRepo(newModel);
            }
            else
            {
                throw new ArgumentException("Invalid values. Model cannot be created");
            }


            //if (name == string.Empty || start_date == string.Empty || engine_size < 0 || horsepower < 0 || price < 0)
            //{
            //    throw new ArgumentException();
            //}
            //else
            //{
            //    newModel.brand_id = id;
            //    newModel.name = name;
            //    newModel.engine_size = engine_size;
            //    newModel.horsepower = horsepower;
            //    newModel.starting_price = price;
            //}

            //try
            //{
            //    newModel.production_start = DateTime.Parse(start_date);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine("Invalid Date Format please use YYYY-MM-DD");
            //}

            //this.repository.CreateModelRepo(newModel);
        }

        public void CreateExtraLogic(string categoryName, string extraName, string color, string price, string reusable)
        {
            extra newExtra = new extra();
            int newPrice = this.SetIntValue(price);
            int reuseAble = this.SetIntValue(reusable);

            if (categoryName != string.Empty && extraName != string.Empty && newPrice > 0 && reuseAble >= 0 && reuseAble <= 1)
            {
                newExtra.category_name = categoryName;
                newExtra.name = extraName;
                newExtra.color = color;
                newExtra.price = newPrice;
                newExtra.reuseable = (byte)reuseAble;
                this.repository.CreateExtraRepo(newExtra);
            }
            else
            {
                throw new ArgumentException("Invalid parmeters. Extra cannot be created");
            }
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
        public void UpdateBrandLogic(string newId, string name, string country, string founded, string revenue)
        {
            int toBeUpdated;
            if (int.TryParse(newId, out toBeUpdated) && this.BrandExists(toBeUpdated))
            {
                string newName = name;
                string newCountry = country;
                DateTime newDate = this.SetDate(founded);
                int newRevenue = this.SetPositiveIntValue(revenue);
                this.repository.UpdateBrandRepo(toBeUpdated, newName, newCountry, newDate, newRevenue);
            }
            else
            {
                throw new ArgumentException("Invalid parameters. Brand cannot be updated");
            }

            //IEnumerable<car_brands> brands = this.repository.GetBrandsRepo();
            //IEnumerable<int> brand_ids = brands.Select(b => b.id);
            //int toBeUpdatedId;
            //DateTime newDate = default(DateTime);
            //int newRevenue = default(int);

            //if (this.IsStringNumber(newId) && brand_ids.Contains(int.Parse(newId)))
            //{
            //    toBeUpdatedId = int.Parse(newId);

            //    if (founded != string.Empty)
            //    {
            //        newDate = this.SetDate(founded);
            //    }

            //    if (revenue != string.Empty && this.IsStringNumber(revenue))
            //    {
            //        newRevenue = int.Parse(revenue);

            //        if (newRevenue <= 0)
            //        {
            //            throw new ArgumentException("Revenue cannot be minus");
            //        }
            //    }

            //    this.repository.UpdateBrandRepo(toBeUpdatedId, name, country, newDate, newRevenue);
            //}
            //else
            //{
            //    if (!this.IsStringNumber(newId))
            //    {
            //        throw new ArgumentException("Please select a number");
            //    }
            //    else
            //    {
            //        throw new ArgumentException("Brand cannot be found.Please select again");
            //    }
            //}

            //if (this.IsStringNumber(id) && brand_ids.Contains(int.Parse(id)))
            //{
            //    toBeUpdatedId = int.Parse(id);

            //    if (name != string.Empty)
            //    {
            //        newName = name;
            //    }

            //    if (country != string.Empty)
            //    {
            //        newCountry = country;
            //    }

            //    if (founded != string.Empty)
            //    {

            //        if (DateTime.TryParse(founded, out newDate))
            //        {
            //            string.Format("yyyy-MM-dd", newDate);

            //            if (newDate.Year > DateTime.Now.Year || newDate.Month > 12 || newDate.Day > DateTime.DaysInMonth(newDate.Year, newDate.Month))
            //            {
            //                throw new InvalidDateFormatException("Invalid date. Please select a proper date prior to today's date");
            //            }
            //        }
            //        else
            //        {
            //            throw new InvalidDateFormatException("Invalid date format. Please use date format YYYY-MM-DD");
            //        }

            //    }

            //    if (revenue != string.Empty && this.IsStringNumber(revenue))
            //    {
            //        newRevenue = int.Parse(revenue);

            //        if (newRevenue < 0)
            //        {
            //            throw new ArgumentException("Revenue cannot be minus");
            //        }
            //    }

            //    this.repository.UpdateBrandRepo(toBeUpdatedId, newName, newCountry, newDate, newRevenue);
            //}
            //else
            //{
            //    if (!this.IsStringNumber(id))
            //    {
            //        throw new ArgumentException("Please select a number");
            //    }
            //    else
            //    {
            //        throw new ArgumentException("Brand cannot be found.Please select again");
            //    }
            //}

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
        public void UpdateModelLogic(string selected, string name, string productionStart, string engineSize, string horsePower, string startingPrice)
        {
            int selectedModelId;
            string newName = name;
            DateTime newProdStart = this.SetDate(productionStart);
            int newEngine = this.SetIntValue(engineSize);
            int newHorseP = this.SetIntValue(horsePower);
            int newPrice = this.SetIntValue(startingPrice);

            if (int.TryParse(selected, out selectedModelId) && this.ModelExists(selectedModelId) && newEngine > 0 && newHorseP > 0 && newPrice > 0)
            {
                this.repository.UpdateModelRepo(selectedModelId, newName, newProdStart, newEngine, newHorseP, newPrice);
            }
            else
            {
                throw new ArgumentException("Invalid parameters. Model cannot be updated");
            }

            //IEnumerable<car_models> models = this.repository.GetModelsRepo();
            //IEnumerable<int> model_ids = models.Select(m => m.id);
            //string newName = string.Empty;
            //DateTime newStartDate = default(DateTime);
            //int newEngineSize = default(int);
            //int newHorsePower = default(int);
            //int newStartPrice = default(int);

            //if (this.IsStringNumber(selected) && model_ids.Contains(int.Parse(selected)))
            //{
            //    int toBeUpdated = int.Parse(selected);
            //    newStartDate = this.SetDate(productionStart);

            //}
            //else
            //{
            //    if (!this.IsStringNumber(selected))
            //    {
            //        throw new ArgumentException("Please select a number");
            //    }
            //    else
            //    {
            //        throw new ArgumentException("Model cannot be found.Please select again");
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selected"></param>
        /// <param name="catname"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="newReuse"></param>
        public void UpdateExtraLogic(string selected, string catname, string name, string price, string newReuse)
        {
            int selectedExtra;
            string newCatName = catname;
            string newExtraName = name;
            int newPrice = this.SetPositiveIntValue(price);
            int reUsAble = this.SetPositiveIntValue(newReuse);

            if (int.TryParse(selected, out selectedExtra) && this.ExtraExists(selectedExtra) && reUsAble > 0 && reUsAble <= 1)
            {
                this.repository.UpdateExtraRepo(selectedExtra, newCatName, newExtraName, newPrice, reUsAble);
            }
            else
            {
                throw new ArgumentException("Invalid parameters. Brand cannot be updated");
            }
        }

        private bool IsStringNumber(string txt)
        {
            bool isNumber;

            int i = 0;
            if (txt != string.Empty && txt[0] == '-')
            {
                i = 1;
            }

            while (i < txt.Length && char.IsNumber(txt[i]))
            {
                i++;
            }

            // if i is >= the length of txt that means all the chars in txt is a number.
            isNumber = i >= txt.Length && txt != string.Empty;

            return isNumber;
        }

        private DateTime SetDate(string date)
        {
            DateTime newDate;

            if (DateTime.TryParse(date, out newDate))
            {
                string.Format("yyyy-MM-dd", newDate);

                if (newDate.Year > DateTime.Now.Year || newDate.Month > 12 || newDate.Day > DateTime.DaysInMonth(newDate.Year, newDate.Month))
                {
                    throw new InvalidDateFormatException("Invalid date. Please select a proper date prior to today's date");
                }
            }
            else if (date == string.Empty)
            {
                return default(DateTime);
            }
            else
            {
                throw new InvalidDateFormatException("Invalid date format. Please use date format YYYY-MM-DD");
            }

            return newDate;
        }

        private int SetPositiveIntValue(string value)
        {
            int result = default(int);

            if (value != string.Empty)
            {
                if (int.TryParse(value, out result) && result > 0)
                {
                    return result;
                }
                else
                {
                    throw new ArgumentException("Please enter a positve Number");
                }
            }

            return result;
        }

        private int SetIntValue(string value)
        {
            int result = default(int);

            if (value != string.Empty)
            {
                int.TryParse(value, out result);
            }

            return result;
        }

        private bool BrandExists(int id)
        {
            IEnumerable<int> brands_id = this.repository
                .GetBrandsRepo()
                .Select(b => b.id);

            return brands_id.Contains(id);
        }

        private bool ModelExists(int id)
        {
            IEnumerable<int> model_id = this.repository
                .GetModelsRepo()
                .Select(b => b.id);

            return model_id.Contains(id);
        }

        private bool ExtraExists(int id)
        {
            IEnumerable<int> extras_id = this.repository
                .GetBrandsRepo()
                .Select(b => b.id);

            return extras_id.Contains(id);
        }

        private bool ModelExtraConnectionExists(int id)
        {
            IEnumerable<int> connections = this.repository
                .GetExtraConnectionRepo()
                .Select(e => e.id);

            return connections.Contains(id);
        }
    }
}
