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
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Modify product");
                Console.WriteLine("3. Delete product");
                Console.WriteLine("4. Show products");
                Console.WriteLine("5. Show products by sort");
                Console.WriteLine("6. Show products price range");
                Console.WriteLine("7. Find product by name");

                Console.WriteLine("0. Return");
                Console.WriteLine("Please, select an option");

                while (!int.TryParse(Console.ReadLine(), out selectedOption))
                {
                    Console.WriteLine("Please enter valid option:");
                }

                switch (selectedOption)
                {
                        case 0: break;
                        case 1: MenuService.AddProducts(); break;
                        case 2: Console.WriteLine(); break;
                        case 3: Console.WriteLine(); break;
                        case 4: MenuService.ShowProducts(); break;
                        case 5: Console.WriteLine(); break;
                        case 6: Console.WriteLine(); break;
                        case 7: Console.WriteLine(); break;
                        default: Console.WriteLine("No such option"); break;
                }     
            } while (selectedOption != 0);
        }

        public static void DisplaySaleMenu()
        {
            int selectedOption;

            do
            {
                Console.WriteLine("1. Add new sale");
                Console.WriteLine("2. Returning any product");
                Console.WriteLine("3. Delete sale");
                Console.WriteLine("4. Show sales");
                Console.WriteLine("5. Show sales by date range");
                Console.WriteLine("6. Show products price range");
                Console.WriteLine("7. Find product by date");
                Console.WriteLine("8. Show product by name");

                Console.WriteLine("0. Return");
                Console.WriteLine("Please, select an option");

                while (!int.TryParse(Console.ReadLine(), out selectedOption))
                {
                    Console.WriteLine("Please enter valid option:");
                }

                switch (selectedOption)
                {
                    case 0: break;
                    case 1: MenuService.AddSale(); break;
                    case 2: Console.WriteLine(); break;
                    case 3: Console.WriteLine(); break;
                    case 4: MenuService.ShowSales(); break;
                    case 5: Console.WriteLine(); break;
                    case 6: Console.WriteLine(); break;
                    case 7: Console.WriteLine(); break;
                    case 8: Console.WriteLine(); break;

                    default: Console.WriteLine("No such option"); break;
                }
            } while (selectedOption != 0);


        }
    }
}
