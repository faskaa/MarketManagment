using MarketManagment.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Helpers
{
    public class SubMenuHelper
    { 
        public static void DisplayProductMenu()
        {
            int selectedOption;

            do 
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-------------------------------");                
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Upgrade product");
                Console.WriteLine("3. Delete product");
                Console.WriteLine("4. Show products");
                Console.WriteLine("5. Show products by category");
                Console.WriteLine("6. Show products price range");
                Console.WriteLine("7. Show product by name");
                Console.WriteLine(" ");
                Console.ResetColor();
                
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("0. Return");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Please, select an option");
                Console.WriteLine("---------------------------------");
                Console.ResetColor();


                while (!int.TryParse(Console.ReadLine(), out selectedOption))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid option:");
                    Console.ResetColor();
                }

                switch (selectedOption)
                {
                        case 0: break;
                        case 1: MenuService.AddProducts(); break;
                        case 2: MenuService.UpdateProduct(); break;
                        case 3: MenuService.DeleteProduct(); break;
                        case 4: MenuService.ShowProducts(); break;
                        case 5: MenuService.ShowProductByCategory(); break;
                        case 6: MenuService.ShowProductByPrice(); break;
                        case 7: MenuService.ShowProductByName(); break;
                        default: Console.WriteLine("No such option"); break;
                }     
            } while (selectedOption != 0);
        }

        public static void DisplaySaleMenu()
        {
            int selectedOption;

            do
            {

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Add new sale");
                Console.WriteLine("2. Returning any product");
                Console.WriteLine("3. Delete sale");
                Console.WriteLine("4. Show sales");
                Console.WriteLine("5. Show sales by date range");
                Console.WriteLine("6. Show sales price range");
                Console.WriteLine("7. Show sales by date");
                Console.WriteLine("8. Show sales by ID");
                Console.ResetColor();

                Console.ForegroundColor= ConsoleColor.DarkRed;
                Console.WriteLine("0. Return");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Please, select an option");
                Console.WriteLine("------------------------------");
                Console.ResetColor();

                while (!int.TryParse(Console.ReadLine(), out selectedOption))
                {
                    Console.WriteLine("Please enter valid option:");
                }

                switch (selectedOption)
                {
                    case 0: break;
                    case 1: MenuService.AddSale(); break;
                    case 2: MenuService.DeleteSale(); break;
                    case 3: MenuService.DeleteAllSale(); break;
                    case 4: MenuService.ShowSales(); break;
                    case 5: MenuService.ShowSaleByDateRange(); break;
                    case 6: MenuService.ShowSalesByPriceRange(); break;
                    case 7: MenuService.ShowSaleByDate(); break;
                    case 8: MenuService.ShowSaleById(); break;

                    default: Console.WriteLine("No such option"); break;
                }
            } while (selectedOption != 0);


        }
    }
}
