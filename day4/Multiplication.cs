using System;

namespace TestConsole.day4
{
    public class Multiplication
    {

        public static void Run()

        {
            // ตารางสูตรคูณ 1-12 
            for (int i = 1; i <= 12; i++)

            {
                Console.WriteLine("--- {0} ---", i);
                for (int j = 1; j <= 12; j++)
                {
                    Console.WriteLine("{0} x {1} = {2}", i, j, i * j);
                }
                Console.WriteLine("-----------------");
            }
        }
    }
}