using MarketManagment.Data.Enums;
using MarketManagment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Services.Abstract
{
    public interface IMarketService
    {       
        public List<Sale> GetSales();
        public List<Product> GetProducts();
        //sales item i helelik silirem => elave et
        public int AddSale(decimal price,  DateTime date);
        public int ReturnSale(int id);
        public int ReturnAllSale(Sale sale);
        public List<Sale> GetSaleByDateRange(DateTime minDate, DateTime maxDate);
        public List<Sale> GetSaleByDate(DateTime date);
        public List<Sale> GetSaleByPriceRange(decimal minPrice, decimal maxPrice);
        public List<Sale> GetSaleById(int id);

        public int AddProduct(string name, decimal price, Category category, int quantity);
        public int ChangeProduct(int id);
        public Category GetCategory(Category category);
        public List<Product> GetProductByPriceRange(Decimal minPrice, decimal maxPrice);
        public List<Product> GetProductByPriceName(string name);
    }
}
