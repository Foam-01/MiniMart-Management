using System;

namespace TestConsole.day4
{
    public class NesTedLoop
    {

        public static void Run()
        {
            for (int i = 0; i < 3; i++)
            {


                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("i = {0}, j = {1}", i, j);
                }
                Console.WriteLine("-----------------");
            }
        }
    }
}