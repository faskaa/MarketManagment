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
            Thread.Sleep(3000);
            Console.Clear();
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\r\n  _      \r\n | |     \r\n | |     \r\n | |     \r\n | |____ \r\n |______|\r\n         \r\n         \r\n");
                Thread.Sleep(300);
                Console.Clear();
                Console.Write("\r\n        \r\n        \r\n   ___  \r\n  / _ \\ \r\n | (_) |\r\n  \\___/ \r\n        \r\n        \r\n");
                Thread.Sleep(300);
                Console.Clear();
                Console.Write("\r\n        \r\n        \r\n   __ _ \r\n  / _` |\r\n | (_| |\r\n  \\__,_|\r\n        \r\n        \r\n");
                Thread.Sleep(300);
                Console.Clear();
                Console.Write("\r\n      _ \r\n     | |\r\n   __| |\r\n  / _` |\r\n | (_| |\r\n  \\__,_|\r\n        \r\n        \r\n");
                Thread.Sleep(300);
                Console.Clear();
                Console.Write("\r\n  _ \r\n (_)\r\n  _ \r\n | |\r\n | |\r\n |_|\r\n    \r\n    \r\n");
                Thread.Sleep(300);
                Console.Clear();
                Console.Write("\r\n        \r\n        \r\n  _ __  \r\n | '_ \\ \r\n | | | |\r\n |_| |_|\r\n        \r\n        \r\n");
                Thread.Sleep(300);
                Console.Clear();
                Console.Write("\r\n        \r\n        \r\n   __ _ \r\n  / _` |\r\n | (_| |\r\n  \\__, |\r\n   __/ |\r\n  |___/ \r\n");
                Thread.Sleep(300);
                Console.Clear();
                Console.WriteLine(" ");
                
            }
            do
            {
               

                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.WriteLine("1. Prosses for products");
                Console.WriteLine("2. Prosses for sales");
               
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("0. Exit");
                Console.ResetColor();

                while (!int.TryParse(Console.ReadLine(), out selectedOptions))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid option:");
                    Console.ResetColor();
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