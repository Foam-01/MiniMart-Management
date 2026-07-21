using System;

namespace TestConsole.day5
{
    public class Array2DLoop
    {

        public static void Run()
        {
            int[,] arr =
            {
                {1,2,3},
                {4,5,6}

            };

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }
    }
}