using System;

namespace TestConsole.day4
{
    public class whileLoop
    {

        public static void Run()
        {
           int x = 0;

           while (x < 10)
            {
                Console.WriteLine("x = {0}", x);
                x++;
            }
        }
    }
}