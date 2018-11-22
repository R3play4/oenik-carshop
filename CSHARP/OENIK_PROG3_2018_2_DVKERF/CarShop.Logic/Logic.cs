namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Repository;
    using Data;

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
            this.repository = new Repository();
        }

        /// <summary>
        /// Calls Repository List Brand
        /// </summary>
        public void ListBrandsLogic()
        {
            this.repository.ListBrandsRepo();
        }

        /// <summary>
        /// Calls Repository List Extra
        /// </summary>
        public void ListExtraLogic()
        {
            this.repository.ListExtraRepo();
        }

        /// <summary>
        /// Calls Repository List Model
        /// </summary>
        public void ListModelsLogic()
        {
            this.repository.ListModelsRepo();
        }

        /// <summary>
        /// Calls CreateBrand method of the repository
        /// </summary>
        /// <param name="brand">new brand parameter that was gathered form the user in the Console Layer</param>
        public void CreateBrandLogic(car_brands brand)
        {
            this.repository.CreateBrandRepo(brand);
        }

        public void DeleteBrand(string name)
        {
            this.repository.DeleteBrandRepo(name);
        }
    }
}
