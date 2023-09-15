using MarketManagment.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Data.Models
{
    public class Sale : BaseModel
    {
        private static int id = 0;
       
        public Sale()
        {
            id = Id;
            Id++;
        }

        public decimal Price { get; set; }
        public SalesItems SalesItems { get; set; }
        public DateTime Date { get; set; }


    }
}
