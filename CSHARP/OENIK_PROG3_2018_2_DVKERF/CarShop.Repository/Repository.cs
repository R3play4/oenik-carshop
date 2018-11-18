using CarShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Repository
{
    public class Repository : IRepository
    {
        //Vagy CarShop.Data ban lesz egy DB mező vagy itt. 
        CarShopDBaseEntities dataBase = new CarShopDBaseEntities();

        public void ListBrandsRepo()
        {
            //selects car brands from DB , for test purposes.
            var result = dataBase.car_brands.Select(b => b.name);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void ListModelsRepo()
        {
            var result = dataBase.car_models.Select(m => m.name);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
