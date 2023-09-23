using ConsoleTables;
using MarketManagment.Data.Enums;
using MarketManagment.Data.Models;
using MarketManagment.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Xml.Linq;

namespace MarketManagment.Services.Concrete
{
    public class MenuService
    {
        private static IMarketService marketService = new MarketService();
        
        //this method adds sale 
        public static void AddSale()
        {
            try
            {
                Console.WriteLine("Enter count of sale items");
                int itemCount = int.Parse(Console.ReadLine()!);

                var saleItems = new List<SalesItems>();
                for (int i = 1; i <= itemCount; i++)
                {
                    Console.WriteLine($"Enter product Id for item {i}");
                    int id = int.Parse(Console.ReadLine()!);

                    Console.WriteLine($"Enter Product quantity for product {id}");
                    int quantity = int.Parse(Console.ReadLine()!);

                    saleItems.Add(new SalesItems()
                    {
                        ProductId = id,
                        Quantity = quantity
                    }); ;
                    Console.WriteLine("Would you like to add another product for sale (yes/no)");
                    string answer = Console.ReadLine()!;
                    if (answer != "yes")
                    {
                        break;
                    }
                }

                Console.WriteLine("Enter datetime");
                var dateTime = DateTime.ParseExact(Console.ReadLine()!, "dd.MM.yyyy HH:mm:ss", null);

                var saleCount = marketService.AddSale(saleItems, dateTime);
                Console.WriteLine($"Sale count: {saleCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        //this method show sale
        public static void ShowSales()
        {
            try
            {
                var saleList = marketService.GetSales();
                var tableSale = new ConsoleTable("Sale Id", "Price", "DateTime");
                foreach (var sale in saleList)
                {
                    sale.Amount = 0;
                    foreach (var item in sale.SalesItems)
                    {
                        sale.Amount += item.TotalPrice;
                    }
                    tableSale.AddRow(sale.Id, sale.Amount, sale.Date);
                }
                tableSale.Write();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }      
        }

        //this method add product
        public static void AddProducts()
        {
            try
            {
                Console.WriteLine("Enter product's name");
                string name = Console.ReadLine()!;

                Console.WriteLine("Enter product's price");
                decimal price = decimal.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter product's category");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine()!);

                Console.WriteLine("Enter product's quantity");
                int quantity = int.Parse(Console.ReadLine()!);

                int id = marketService.AddProduct(name, price, category, quantity);

                Console.WriteLine($"Product with :{id} created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
         
        //this method show products
        public static void ShowProducts()
        {
            try
            {
                var table = new ConsoleTable("ID", "Name", "Price", "Category", "Quantity");

                foreach (var product in marketService.GetProducts())
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Category, product.Quantity);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        //this method show product by name 
        public static void ShowProductByName()
        {
            try
            {
                Console.WriteLine("Enter product's name");
                string name = Console.ReadLine()!;

                var table = new ConsoleTable("ID", "Name", "Price", "Category", "Quantity");

                foreach (var product in marketService.GetProductByName(name))
                {
                    table.AddRow(product.Id , product.Name , product.Price ,product.Category, product.Quantity);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //this method show product by category
        public static void ShowProductByCategory() 
        {
            try
            {
                Console.WriteLine("Enter product's category");
                var category = (Category)Enum.Parse(typeof(Category), Console.ReadLine()!);

                var table = new ConsoleTable("ID", "Name", "Price", "Category", "Quantity");

                foreach (var product in marketService.GetProductByCategory(category))
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Category, product.Quantity);
                }

                table.Write();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //this method show product by price
        public static void ShowProductByPrice()
        {
            try
            {
                Console.WriteLine("Enter product's minimum price");
                decimal minPrice = decimal.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter product's maximum price");
                decimal maxPrice = decimal.Parse(Console.ReadLine()!);

                var table = new ConsoleTable("ID", "Name", "Price", "Category", "Quantity");

                foreach (var product in marketService.GetProductByPriceRange(minPrice, maxPrice))
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Category, product.Quantity);
                }

                table.Write();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //this product delete product
        public static void DeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter product's ID");
                int id = int.Parse(Console.ReadLine()!);

                marketService.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }

        //this method update product's name , price , category , quantity
        public static void UpdateProduct()
        {
            try
            {
                Console.WriteLine("Enter product's ID");
                int id = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter new name");
                string newName = Console.ReadLine()!;
                

                Console.WriteLine("Enter new price");
                decimal newPrice = decimal.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter new category");
                Category newCategory = (Category)Enum.Parse(typeof(Category), Console.ReadLine()!);

                Console.WriteLine("Enter new quantity");
                int newQuantity = int.Parse(Console.ReadLine()!);
                Console.ForegroundColor= ConsoleColor.Green;
                marketService.ChangeProduct(id , newName , newPrice , newCategory , newQuantity );
                Console.WriteLine($"Product with ID: {id} => name changed: {newName}" );
                Console.WriteLine($"Product with ID: {id} => price changed: {newPrice}");
                Console.WriteLine($"Product with ID: {id} => category changed: {newCategory}");
                Console.WriteLine($"Product with ID: {id} => quantity changed: {newQuantity}");
                Console.WriteLine("DONE!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //this method show sale by date
        public static void ShowSaleByDate()
        {
            try
            {
                Console.WriteLine("Enter date");
                var date = DateTime.ParseExact(Console.ReadLine()!, "dd.MM.yyyy HH:mm:ss", null);

                var table = new ConsoleTable("Sale ID", "Amount", "DateTime");

                foreach (var sale in marketService.GetSaleByDate(date))
                { 
                    table.AddRow(sale.Id , sale.Amount , sale.Date);
                }

                table.Write();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        //this method show sale by ID
        public static void ShowSaleById() 
        {
            try
            {
                Console.WriteLine("Enter ID");
                var id = int.Parse(Console.ReadLine()!);

                var productList = marketService.GetProducts();

                var table = new ConsoleTable("Sale ID", "Product Name", "Product Price", "Quantity", "Total Price");
                foreach (var item in marketService.GetSaleById(id).SalesItems)
                {
                    var products = productList.FirstOrDefault(x=>x.Id == item.ProductId);
                 
                    if (products == null)
                        throw new Exception("Not found!");

                    table.AddRow(item.SaleId, products.Name, products.Price, item.Quantity, item.TotalPrice);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //this method show sales by price range
        public static void ShowSalesByPriceRange()
        {
            try
            {
                Console.WriteLine("Enter minimum price");
                decimal minPrice = decimal.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter maximum price");
                decimal maxPrice = decimal.Parse(Console.ReadLine()!);

                var table = new ConsoleTable("Sale Id", "Price", "SaleItems Count", "DateTime");
                foreach (var item in marketService.GetSaleByPriceRange(minPrice , maxPrice))
                {
                    table.AddRow(item.Id, item.Amount, item.SalesItems.Count, item.Date);
                }
               
                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

         //this method delete all sale
        public static void DeleteAllSale()
        {
            try
            {
                Console.WriteLine("Please enter Id of sale");
                int id = int.Parse(Console.ReadLine()!);

                marketService.DeleteAllSale(id);
                Console.WriteLine($"Product with ID:{id} was deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //this method delete sale
        public static void DeleteSale()
        {
            try
            {
                Console.WriteLine("Enter Sale Id: ");
                int saleId = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter Product Id: ");
                int productId = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter Quantity of Product: ");
                int count = int.Parse(Console.ReadLine()!);

                var deletedSale = marketService.DeleteSale(saleId, productId, count);
                Console.WriteLine($"Withdraw the Product with ProductId={deletedSale}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //this method show sale by date range
        public static void ShowSaleByDateRange()
        {
            try
            {
                Console.WriteLine("Please Enter minimum  datetime");
                var minDate = DateTime.ParseExact(Console.ReadLine()!, "dd.MM.yyyy HH:mm:ss", null);


                Console.WriteLine("Please Enter maximum  datetime");
                var maxDate = DateTime.ParseExact(Console.ReadLine()!, "dd.MM.yyyy HH:mm:ss", null);



                var table = new ConsoleTable("ID", "Amount", "Quantity", "Date");

                foreach (var sale in marketService.GetSaleByDateRange(minDate, maxDate))
                {
                    foreach (var item in sale.SalesItems)
                    {
                        table.AddRow(sale.Id, sale.Amount, item.Quantity, sale.Date);
                    }

                    table.Write();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




    }

}
