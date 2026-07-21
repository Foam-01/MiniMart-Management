using System;

namespace TestConsole.day4
{
    public class DoWhileLoop
    {

        public static void Run()
        {
            int x = 0;

            do
            {
                Console.WriteLine("x = {0}", x);
                x++;
            } while (x < 10);
        }
    }
}