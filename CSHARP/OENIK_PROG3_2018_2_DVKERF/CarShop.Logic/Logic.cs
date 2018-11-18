using CarShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Logic
{
    public class Logic : ILogic
    {
        IRepository method;
        public Logic()
        {
            method = new Repository.Repository();
        }
        public void ListBrandsLogic()
        {
            method.ListBrandsRepo();
        }

        public void ListModelsLogic()
        {
            method.ListModelsRepo();
        }
    }
}
