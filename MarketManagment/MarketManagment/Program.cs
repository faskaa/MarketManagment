using MarketManagment.Helpers;
using System.Xml;

namespace MarketManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int selectedOptions;

            Console.WriteLine("Welcome");

            do
            {
                Console.WriteLine("1. Prosses for products");
                Console.WriteLine("2. Prosses for sales");
                
                Console.WriteLine("0. Exit");

                while (!int.TryParse(Console.ReadLine(), out selectedOptions))
                {
                    Console.WriteLine("Please enter valid option:");
                }

                switch (selectedOptions)
                {
                    case 0: break;
                    case 1: SubMenuHelper.DisplayProductMenu(); break;
                    case 2: SubMenuHelper.DisplaySaleMenu(); break;
                    default: Console.WriteLine("No such option"); break;
                }
            }
            while (selectedOptions != 0);


        }
    }
}