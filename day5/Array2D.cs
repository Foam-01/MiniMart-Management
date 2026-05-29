using System;

namespace TestConsole.day5
{
    public class array2D
    {

        public static void Run()
        {
            int[,] arr =
            {
                { 1, 2,  },
                { 4, 5,  },
                { 7, 8,  }
            };
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("=====================================");

            int[,] arr2 = new int[3, 2];
            arr2[0, 0] = 1;
            arr2[0, 1] = 2;
            arr2[1, 0] = 4;
            arr2[1, 1] = 5;
            arr2[2, 0] = 7;
            arr2[2, 1] = 8;

            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Console.Write(arr2[i, j] + "\t");
                }
                Console.WriteLine();
            }

           
        }
    }
}