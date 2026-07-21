using System;

namespace TestConsole.day5
{
    public class Array1
    {

        public static void Run()
        {
            int [] myArray = { 10, 20, 30, 40, 50 };
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.WriteLine("myArray[{0}] = {1}", i, myArray[i]);
                }

        }
    }
}