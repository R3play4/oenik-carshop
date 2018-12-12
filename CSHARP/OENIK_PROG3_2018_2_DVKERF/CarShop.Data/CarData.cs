using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data
{
    public class CarData
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int? Price { get; set; }

        public CarData(int id, string fullname, int? price)
        {
            this.Id = id;
            this.FullName = fullname;
            this.Price = price;
        }
    }
}
