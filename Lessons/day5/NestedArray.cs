using System;

namespace TestConsole.day5
{
    public class NestedArray
    {

        public static void Run()
        {
            int[] child1 = { 1, 2, 3 };
            int[] child2 = { 4, 5, 6 };

            int[][] arr1 = { child1, child2 };



            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr1[i].Length; j++)
                {
                    Console.Write(arr1[i][j] + "\t");
                }
                Console.WriteLine();
            }


        }
    }
}