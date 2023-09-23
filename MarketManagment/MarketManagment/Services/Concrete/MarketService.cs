using MarketManagment.Data.Enums;
using MarketManagment.Data.Models;
using MarketManagment.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public int AddSale(List<SalesItems> salesItems, DateTime date)
        {
            if (salesItems == null || !salesItems.Any())
                throw new Exception("There are no sale items");

            var sale = new Sale()
            {
                Date = date,
                SalesItems = new List<SalesItems>()
            };

            decimal totalPrice = 0;
            foreach (var item in salesItems)
            {

                if (item.Quantity <= 0)
                    throw new Exception("Quantity can't be less than 0!");

                var product = products.FirstOrDefault(x => x.Id == item.ProductId);
                if (product is null)
                    throw new Exception($"Product with ID {item.ProductId} not found.");

                if (product.Quantity < item.Quantity)
                    throw new Exception("Not enough quantity available for sale");

                item.TotalPrice = product.Price * item.Quantity;

                var saleItem = new SalesItems()
                {
                    SaleId = sale.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice
                };
                sale.SalesItems.Add(saleItem);
                product.Quantity -= saleItem.Quantity;

            }

            sales.Add(sale);

            return sale.SalesItems.Count;
        }


        public int ChangeProduct(int id , string newName , decimal newPrice , Category newCategory, int newQuantity)
        {
            if(id < 0) 
                throw new Exception("ID can't be less than 0");

            if (string.IsNullOrWhiteSpace(newName))
                throw new Exception("Name can't be empty");

            if (newPrice < 0)
                throw new Exception("Price can't be less than 0");
          
            var product  = products.Find(x => x.Id == id);
            
            if (product == null)
                throw new Exception($"Product  with ID {id} not found!");
            
            product.Name = newName;
            product.Price = newPrice;
            product.Category = newCategory;
            product.Quantity = newQuantity;
            
            return product.Id;
        }

        public int DeleteProduct(int id)
        {
            if (id < 0)
                throw new Exception("Id can't be less than 0!");

            var product = products.FirstOrDefault(x=>x.Id == id);

            if (product is null)
                throw new Exception($"Patient with ID:{id} was not found!");

            products.Remove(product);

            Console.WriteLine($"Product with ID:{id} deleted ");
            return id;
        }

        public List<Product> GetProductByCategory(Category category)
        {
            var product = products.Where(x => x.Category == category).ToList();
            
            if (product == null)
                throw new Exception("Product not found!");

            return product;
        }

        public List<Product> GetProductByName(string name)
        {
           if (string.IsNullOrWhiteSpace(name))
              throw new Exception("Name can't be empty!");
            
            var product = products.Where(x=>x.Name == name).ToList();
            if (product == null)
                throw new Exception("Product not found!");
          
            return product.ToList();
        }

        public List<Product> GetProductByPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice > maxPrice)
                throw new Exception("Maximum price can't be less than minimum price");
         
            var prod = products.Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToList();
           if(prod.Count == 0)
                throw new Exception("Product not found");

            return prod.ToList();
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Sale> GetSaleByDate(DateTime date)
        {
            var salebydate = sales.Where(x=>x.Date == date).ToList();
            return salebydate;
        }

        public List<Sale> GetSaleByDateRange(DateTime minDate, DateTime maxDate)
        {
            if (minDate > maxDate)
                throw new Exception("Maximum date can't be less than minimum date");

            var saleByDateRange = sales.Where(x => x.Date > minDate && x.Date < maxDate).ToList();

            if (saleByDateRange == null)
                throw new Exception("No products available in this range");

            return saleByDateRange;
        }

        public Sale GetSaleById(int id)
        {

            if (id < 0)
                throw new Exception("Id can't be 0");
            
            var saleID = sales.FirstOrDefault(x => x.Id == id);

            if (saleID == null)
                throw new Exception("Not Found!");

            return saleID;
            

            if (id <= 0)
                throw new Exception("SaleId can't be less than 0!");

            var saleId = sales.FirstOrDefault(x => x.Id == id);
            if (saleId is null)
                throw new Exception($"Sale with SaleId = {id} is not available");

            return saleId;

        }

        public List<Sale> GetSaleByPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice > maxPrice)

                throw new Exception("Maximum price can't be less than minimum price!");

            if (minPrice < 0)
                throw new Exception("Minumum price can't be less than 0");

            if (minPrice == null)
                throw new Exception("Maximum price can't be empty");

            if (maxPrice == null)
                throw new Exception("Maximum price can't be empty");

            var saleByPriceRange = sales.Where(x => x.Amount > minPrice && x.Amount < maxPrice).ToList();

            if (saleByPriceRange == null)
                throw new Exception("No products available in this range");

            return saleByPriceRange;                    

                throw new Exception("Minimum price can't be less than maximum price");

            var saleByPrice = sales.Where(x => x.Amount > minPrice && x.Amount < maxPrice).ToList();
          
            if (saleByPrice is null)
                throw new Exception("Sale is not aviable");

            return saleByPrice;

        }

        public List<Sale> GetSales()
        {
            return sales;
        }

        public int DeleteAllSale(int id)
        {
            if (id < 0)
                throw new Exception("Id cant be less than 0");

            var sale = sales.FirstOrDefault(x => x.Id == id);
         
            if (sale == null)
                throw new Exception($"Product with Id {id} can not found");
         
            sales.Remove(sale);

            return sale.Id;

        }

        public int DeleteSale(int saleId , int productId , int count)
        {
            if (saleId < 0)
                throw new Exception("Sale Id can't be less than 0!");

            if (productId < 0)
                throw new Exception("Product id can't be less than 0!");

            if (count < 0)
                throw new Exception("Count can't be less than 0!");

            var sale = sales.FirstOrDefault(x => x.Id == saleId);
            if (sale == null)
                throw new Exception($"Sale with Id {saleId} not found!");

            var saleItem = sale.SalesItems.FirstOrDefault(x => x.ProductId == productId);
            if (saleItem == null)
                throw new Exception($"SaleItem with Id {productId} not found!");

            var product = products.FirstOrDefault(x => x.Id == saleItem.ProductId);

            if (saleItem.Quantity < count)
                throw new Exception($"Max {saleItem.Quantity} product could be deleted");

            if (saleItem.Quantity > 0)
            {

                saleItem.Quantity -= count;
                product!.Quantity += count;
                saleItem.TotalPrice -= product.Price * count;
                sale.Amount -= saleItem.TotalPrice;
                if (saleItem.Quantity == 0)
                {
                    sale.SalesItems.Remove(saleItem);
                }

            }

            return productId;
        }


    }
}
