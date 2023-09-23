using MarketManagment.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Data.Models
{
    public class SalesItems : BaseModel
    {
        private static int id = 0;
        
        public SalesItems()
        {
            Id = id;
            id++;
        }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Sale Sales { get; set; }
    }

}
