using ConsoleTables;
using MarketManagment.Data.Enums;
using MarketManagment.Data.Models;
using MarketManagment.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //sales item i helelik silirem => elave et
        public static void AddSale()
        {
            try
            {
                Console.WriteLine("Enter count of sale items");
                int itemCount = int.Parse(Console.ReadLine()!);

                var saleItems = new List<SalesItems>();

                for (int i = 0; i < itemCount; i++)
                {
                    Console.WriteLine($"Enter product Id for item {i}");
                    int id = int.Parse(Console.ReadLine()!);

                    Console.WriteLine($"Enter Product quantity for product {id}");
                    int quantity = int.Parse(Console.ReadLine()!);

                    saleItems.Add(new SalesItems()
                    {
                        ProductId = id,
                        Quantity = quantity,
                    });

                    Console.WriteLine("Enter datetime");
                    var dateTime = DateTime.ParseExact(Console.ReadLine()!, "dd.MM.yyyy HH:mm:ss", null);

                    var saleCount = marketService.AddSale(saleItems, dateTime);
                    Console.WriteLine($"Sale count: {saleCount}");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        public static void ShowSales()
        {
            try
            {
                var table = new ConsoleTable("Sale ID", "amount", "Date");
                foreach (var sale in marketService.GetSales())
                {
                    //foreach (var item in sale.SalesItems)
                    //{
                    //    table.AddRow(sale.Id, item.Id, item.Quantity, sale.Date) ;
                    //}
                    table.AddRow(sale.Id, sale.Amount, sale.Date);


                    table.Write();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

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
            catch (Exception)
            {

                throw;
            }
        }

        
    }

}
