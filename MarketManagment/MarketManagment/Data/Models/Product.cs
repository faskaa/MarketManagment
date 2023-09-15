using MarketManagment.Data.Common;
using MarketManagment.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Data.Models
{
    public class Product : BaseModel
    {
        private static int id = 0;
        public Product()
        {
            Id = id;
            id++;
        }
       
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
    }
}
