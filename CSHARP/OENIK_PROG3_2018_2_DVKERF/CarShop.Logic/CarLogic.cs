// <copyright file="CarLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarShop.Repository;
    using Data;

    /// <summary>
    /// Implements ILogic CRUD operations
    /// </summary>
    public class CarLogic : ICarLogic
    {
        /// <summary>
        /// This will enable to communication with the Repository .dll
        /// </summary>
        private ICarRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarLogic"/> class.
        /// </summary>
        public CarLogic()
        {
            this.SetRepositoryInterface(new CarRepository());
        }

        /// <summary>
        /// Sets the Repository property of the class. This will be used for mocking.
        /// </summary>
        /// <param name="intf">Repositary interface</param>
        public void SetRepositoryInterface(ICarRepository intf)
        {
            this.repository = intf;
        }

        /// <summary>
        /// Gets list of car brands from repo
        /// </summary>
        /// <returns>Enumerable list of car brands that was received from the repository </returns>
        public IEnumerable<car_brands> ListBrandLogic()
        {
            IEnumerable<car_brands> brands = this.repository.ListBrandsRepo();
            return brands;
        }

        /// <summary>
        /// Gets list of extras from the repo
        /// </summary>
        /// <returns>List of extras from the repo</returns>
        public IEnumerable<extra> ListExtraLogic()
        {
            IEnumerable<extra> extras = this.repository.ListExtraRepo();
            return extras;
        }

        /// <summary>
        /// Gets a list of models from the repo
        /// </summary>
        /// <returns>List of models from the repo</returns>
        public IEnumerable<car_models> ListModelLogic()
        {
            IEnumerable<car_models> models = this.repository.ListModelsRepo();
            return models;
        }

        /// <summary>
        /// Gets extra model connections from table. Only the ids will be returened. (No Join)
        /// </summary>
        /// <returns>return content of model extra table</returns>
        public IEnumerable<model_extra_connection> ListConnectionLogic()
        {
            return this.repository.ListExtraConnectionRepo();
        }

        /// <summary>
        /// Gets the connection between the extra and the model from the repository.
        /// </summary>
        /// <returns>Returns a list of Extra and Model conencitons.</returns>
        public IEnumerable<object> ListExtraModelLogic()
        {
            IEnumerable<car_models> models = this.repository.ListModelsRepo();
            IEnumerable<extra> extras = this.repository.ListExtraRepo();
            IEnumerable<model_extra_connection> connections = this.repository.ListExtraConnectionRepo();

            var result = from con in connections
                         join mod in models on con.model_id equals mod.id
                         join ext in extras on con.extra_id equals ext.id
                         select new { ID = con.id, Model = mod.name, Extra = ext.name };
            return result;
        }

        /// <summary>
        /// Joins car brands and car models and create a List of CarData Objects
        /// </summary>
        /// <returns>List of Car Data objects</returns>
        public IEnumerable<CarData> ListFullNamePricesLogic()
        {
            IEnumerable<car_brands> brands = this.repository.ListBrandsRepo();
            IEnumerable<car_models> models = this.repository.ListModelsRepo();

            IEnumerable<CarData> result = from br in brands
                                          join mod in models on br.id equals mod.brand_id
                                          select new CarData(mod.id, br.name + " " + mod.name, mod.starting_price);

            return result;
        }

        /// <summary>
        /// Get Countries and Brands from the repository. Joins Brands and Modles table.
        /// </summary>
        /// <returns>Returns a list of objects from Brands and Models table. </returns>
        public IEnumerable<object> ListCountryBrandLogic()
        {
            IEnumerable<car_brands> brands = this.repository.ListBrandsRepo();
            IEnumerable<car_models> models = this.repository.ListModelsRepo();

            var result = from br in brands
                         join mod in models on br.id equals mod.brand_id
                         select new { Country = br.country, FullName = br.name + " " + mod.name };

            return result;
        }

        /// <summary>
        /// Checks the parameters of the new brand and forwards it to the repository if everything is correct.
        /// </summary>
        /// <param name="name">new name</param>
        /// <param name="country">new country</param>
        /// <param name="url">new url it can be null</param>
        /// <param name="foundationDate">new date </param>
        /// <param name="revenue">new reveneu </param>
        public void CreateBrandLogic(string name, string country, string url, string foundationDate, string revenue)
        {
            car_brands newBrand = new car_brands();
            int newRevenue = this.SetIntValue(revenue);
            DateTime newDate = this.SetDate(foundationDate);

            if (name == string.Empty || country == string.Empty || newDate == default(DateTime) || newRevenue <= 0)
            {
                throw new InvalidParameterException("Invalid values. Brand cannot be created");
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
        }

        /// <summary>
        /// Checks the parameters of the new model and forwards it to the repository if everything is correct.
        /// </summary>
        /// <param name="brandId">new id of the brand of the model</param>
        /// <param name="name">new name</param>
        /// <param name="startDate">new production start date</param>
        /// <param name="engineSize">new engine size</param>
        /// <param name="horsePower">new horspower</param>
        /// <param name="price">new price</param>
        public void CreateModelLogic(string brandId, string name, string startDate, string engineSize, string horsePower, string price)
        {
            car_models newModel = new car_models();
            int newBrandId;
            DateTime newDate = this.SetDate(startDate);
            int newEngine = this.SetIntValue(engineSize);
            int newHorseP = this.SetIntValue(horsePower);
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
                throw new InvalidParameterException("Invalid values. Model cannot be created");
            }
        }

        /// <summary>
        /// Checks the parameters of the new extra and forwards it to the repository if everything is correct.
        /// </summary>
        /// <param name="categoryName">new categpory name for the extra</param>
        /// <param name="extraName"> nam eof the new extra</param>
        /// <param name="color">color of the extra</param>
        /// <param name="price">new price </param>
        /// <param name="reusable">value of the reusable field of the new extra</param>
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
                throw new InvalidParameterException("Invalid parmeters. Extra cannot be created");
            }
        }

        /// <summary>
        /// Checks if the Brand that needs to be deleted is proper. Searches based on Brand Id.
        /// </summary>
        /// <param name="selection">Id of the brand that needs to be deleted</param>
        public void DeleteBrand(string selection)
        {
            IEnumerable<car_brands> brands = this.repository.ListBrandsRepo();

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
                    throw new InvalidParameterException("Invalid id. You have to select number");
                }
                else
                {
                    throw new InvalidParameterException("Brand cannot be found. Please select another one");
                }
            }
        }

        /// <summary>
        /// Checks if the Model that needs to be deleted is proper. Searches based on Model Id.
        /// </summary>
        /// <param name="selection">Id of the model that needs to be deleted.</param>
        public void DeleteModel(string selection)
        {
            IEnumerable<car_models> models = this.repository.ListModelsRepo();

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
                    throw new InvalidParameterException("Invalid id. You have to select number");
                }
                else
                {
                    throw new InvalidParameterException("Conection cannot be found. Please select another one");
                }
            }
        }

        /// <summary>
        /// Checks if the Extra-Model connection that needs to be deleted is proper.
        /// </summary>
        /// <param name="selection">Id of the connection that needs to be deleted.</param>
        public void DeleteConnection(string selection)
        {
            IEnumerable<model_extra_connection> connections = this.repository.ListExtraConnectionRepo();

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
        /// Checks if the Extra that needs to be deleted is proper. Searches based on Extra Id.
        /// </summary>
        /// <param name="selection">Id of the extra that needs to be deleted.</param>
        public void DeleteExtra(string selection)
        {
            IEnumerable<extra> extras = this.repository.ListExtraRepo();
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
                    throw new InvalidParameterException("Invalid id. You have to select number");
                }
                else
                {
                    throw new InvalidParameterException("Extra cannot be found. Please select another one");
                }
            }
        }

        /// <summary>
        /// Checks if the values that will be updated are properly set.
        /// </summary>
        /// <param name="newId">Id of the brand that needs to be updated.</param>
        /// <param name="name">Updated name</param>
        /// <param name="country">Updated country</param>
        /// <param name="founded">new foundation date</param>
        /// <param name="revenue">new revenu</param>m>
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
                throw new InvalidParameterException("Invalid parameters. Brand cannot be updated");
            }
        }

        /// <summary>
        /// Checks if the values that will be updated are properly set.
        /// </summary>
        /// <param name="selected">Id of the model that will be updated.</param>
        /// <param name="name">updated name</param>
        /// <param name="productionStart">updated production start date</param>
        /// <param name="engineSize">Updated engine size</param>
        /// <param name="horsePower">Updated horsepower</param>
        /// <param name="startingPrice">Updated starting price</param>
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
                throw new InvalidParameterException("Invalid parameters. Model cannot be updated");
            }
        }

        /// <summary>
        /// Checks if the values that will be updated are properly set.
        /// </summary>
        /// <param name="selected">Id of the Extra that will be updated.</param>
        /// <param name="catName">Updated category name</param>
        /// <param name="name">updated extra name</param>
        /// <param name="price">updated price </param>
        /// <param name="newReuse">updated ruse field.</param>
        public void UpdateExtraLogic(string selected, string catName, string name, string price, string newReuse)
        {
            int selectedExtra;
            string newCatName = catName;
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
                if (newDate.Year > DateTime.Now.Year || newDate.Month > 12 || newDate.Day > DateTime.DaysInMonth(newDate.Year, newDate.Month))
                {
                    throw new InvalidParameterException("Invalid date. Please select a proper date prior to today's date");
                }
            }
            else if (date == string.Empty)
            {
                return default(DateTime);
            }
            else
            {
                throw new InvalidParameterException("Invalid date format. Please use date format YYYY-MM-DD");
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
                    throw new InvalidParameterException("Please enter a positve Number");
                }
            }

            return result;
        }

        private int SetIntValue(string value)
        {
            int result = default(int);

            if (int.TryParse(value, out result))
            {
                return result;
            }

            return result;
        }

        private bool BrandExists(int id)
        {
            IEnumerable<int> brands_id = this.repository
                .ListBrandsRepo()
                .Select(b => b.id);

            return brands_id.Contains(id);
        }

        private bool ModelExists(int id)
        {
            IEnumerable<int> model_id = this.repository
                .ListModelsRepo()
                .Select(b => b.id);

            return model_id.Contains(id);
        }

        private bool ExtraExists(int id)
        {
            IEnumerable<int> extras_id = this.repository
                .ListBrandsRepo()
                .Select(b => b.id);

            return extras_id.Contains(id);
        }

        private bool ModelExtraConnectionExists(int id)
        {
            IEnumerable<int> connections = this.repository
                .ListExtraConnectionRepo()
                .Select(e => e.id);

            return connections.Contains(id);
        }
    }
}
