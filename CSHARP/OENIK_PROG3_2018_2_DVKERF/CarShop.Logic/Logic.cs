namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Repository;

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
        /// Calls Repository List Brand
        /// </summary>
        public void ListBrandsLogic()
        {
            this.repository.ListBrandsRepo();
        }

        /// <summary>
        /// Calls Repository List Extra
        /// </summary>
        public void ListExtra()
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
    }
}
