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
        public int AddSale(List<SalesItems> salesItems, DateTime date);
        public int DeleteSale(int saleId, int productId, int count);
        public int DeleteAllSale(int id);
        public List<Sale> GetSaleByDateRange(DateTime minDate, DateTime maxDate);
        public List<Sale> GetSaleByDate(DateTime date);
        public List<Sale> GetSaleByPriceRange(decimal minPrice, decimal maxPrice);
        public Sale GetSaleById(int id);

        public int AddProduct(string name, decimal price, Category category, int quantity);
        public List<Product> GetProducts();
        public int DeleteProduct(int id);
        public int ChangeProduct(int id, string newName, decimal newPrice, Category newCategory, int newQuantity);
        public List<Product> GetProductByCategory(Category category);
        public List<Product> GetProductByPriceRange(Decimal minPrice, decimal maxPrice);
        public List<Product> GetProductByName(string name);
    }
}
