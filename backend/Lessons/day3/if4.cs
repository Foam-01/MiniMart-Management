using System;

namespace TestConsole.day3
{
    public class if4
    {

        public static void Run()
        {
            int x = 10;
            int y = 20;

            bool condition1 = (x >= 1 && x <= 5) && (y >= 1 && y <= 5);
            bool condition2 = (x >= 6 && x <= 10) && (y >= 6 && y <= 10);

            if (condition1)
            {
                Console.WriteLine("x and y are between 1 and 5");
            }
            else if (condition2)
            {
                Console.WriteLine("x and y are between 6 and 10");
            }
            else
            {
                Console.WriteLine("x and y are not between 1 and 10");
            }


        }
    }
}