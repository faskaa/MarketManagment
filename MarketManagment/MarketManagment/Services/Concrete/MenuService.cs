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
                Console.WriteLine("Plese enter sale's price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Please enter sale's date");
                DateTime date = DateTime.Parse(Console.ReadLine());

                int id = marketService.AddSale(price, date);

                Console.WriteLine($"Sale with ID:{id} was created!");
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
                var table = new ConsoleTable("ID", "Price", "Sales Items", "Date");

                foreach (var sale in marketService.GetSales())
                {
                    table.AddRow(sale.Id, sale.Price, sale.SalesItems, sale.Date);

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

        
    }

}
