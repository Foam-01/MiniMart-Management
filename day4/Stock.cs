using System;

namespace TestConsole.day4
{
    public class Stock
    {

        public static void Run()
        {
          int totalStock = 100;

          while (totalStock >= 0)
            {
                Console.Write("Enter the quantity to purchase: ");
                int qty = int.Parse(Console.ReadLine());

                if (qty > totalStock)
                {
                    Console.WriteLine("Not enough stock available. Please enter a quantity less than or equal to {0}.", totalStock);
                }
                else
                {
                    totalStock -= qty;
                    Console.WriteLine("Purchase successful! Remaining stock: {0}", totalStock);
                }
            }  
        }
    }
}