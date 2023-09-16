using MarketManagment.Data.Enums;
using MarketManagment.Data.Models;
using MarketManagment.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Services.Concrete
{
    public class MarketService : IMarketService
    {
        private List<Product> products = new();
        private List<Sale> sales = new();
        private List<SalesItems> salesItems = new();

        public int AddProduct(string name, decimal price, Category category, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Fullname can't be empty!");

            if (price < 0)
                throw new Exception("Price can't be 0!");

            var product = new Product
            {
                Name = name,
                Price = price,
                Category = category,
                Quantity = quantity
            };
            
            products.Add(product);

            return product.Id;
        }
        //sales item i helelik silirem => elave et
        public int AddSale(decimal price, DateTime date)
        {   
            var sale = new Sale
            {
                Price = price,
                //SalesItems = salesItems,
                Date = date
            };
            sales.Add(sale);
            return sale.Id;
        }

        public int ChangeProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByPriceName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name can't be empty!");
            
            var Products =products.Find(x => x.Name == name);
            
            if (Products == null)
                throw new Exception("Product with this name not found!");
            
        }

        public List<Product> GetProductByPriceRange(decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Sale> GetSaleByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSaleByDateRange(DateTime minDate, DateTime maxDate)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSaleById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSaleByPriceRange(decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSales()
        {
            return sales;
        }

        public int ReturnAllSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public int ReturnSale(int id)
        {
            throw new NotImplementedException();
        }
    }
}
