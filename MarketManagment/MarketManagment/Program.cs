using MarketManagment.Helpers;
using System.Xml;

namespace MarketManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int selectedOptions;

            string welcome = $"\r\n   ____  __             __  ___           __        __ \r\n  / __ \\/ /_  ____ _   /  |/  /___ ______/ /_____  / /_\r\n / / / / __ \\/ __ `/  / /|_/ / __ `/ ___/ //_/ _ \\/ __/\r\n/ /_/ / /_/ / /_/ /  / /  / / /_/ / /  / ,< /  __/ /_  \r\n\\____/_.___/\\__,_/  /_/  /_/\\__,_/_/  /_/|_|\\___/\\__/  \r\n                                                       \r\n";
            Console.WriteLine(welcome);
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("L");
                Thread.Sleep(200);                              
                Console.Write("O");
                Thread.Sleep(200);                            
                Console.Write("A");
                Thread.Sleep(200);
                Console.Write("D");
                Thread.Sleep(200);
                Console.Write("I");
                Thread.Sleep(200);
                Console.Write("N");
                Thread.Sleep(200);
                Console.Write("G");
                Thread.Sleep(200);
                Console.WriteLine(" ");
            }
            do
            {
               

                Console.ForegroundColor= ConsoleColor.DarkYellow;
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