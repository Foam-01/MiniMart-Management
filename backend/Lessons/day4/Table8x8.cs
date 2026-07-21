using System;

namespace TestConsole.day4
{
    public class Table8x8
    {

        public static void Run()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    Console.Write("{_}\t ");
                }
                Console.WriteLine();
            }
        }
    }
}