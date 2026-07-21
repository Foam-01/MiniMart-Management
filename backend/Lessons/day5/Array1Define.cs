using System;

namespace TestConsole.day5
{
    public class Array1Define
    {

        public static void Run()
        {
            int [] arr = new int [5];
            arr[0] = 10;
            arr[1] = 20;
            arr[2] = 30;
            arr[3] = 40;
            arr[4] = 50;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
            }


        }
    }
}