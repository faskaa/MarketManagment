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

                while (!int.TryParse(Console.ReadLine(), out selectedOptions)) ;
                {
                    Console.WriteLine("Please enter valid option:");
                }

                switch (selectedOptions)
                {
                    case 0: Console.WriteLine(); break;
                    case 1: Console.WriteLine(); break;
                    case 2: Console.WriteLine(); break;
                    default: Console.WriteLine(); break;
                }
            }
            while (selectedOptions != 0);


        }
    }
}