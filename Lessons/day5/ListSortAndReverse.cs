using System;

namespace TestConsole.day5
{
    public class ListSortAndReverse
    {

        public static void Run()
        {
            List<int> list = new List<int>();
            list.Add(50);
            list.Add(20);
            list.Add(40);
            list.Add(10);
            list.Add(30);





            Console.WriteLine("Before Sort");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);

            }
            list.Sort();
            Console.WriteLine("After Sort");
            for (int j = 0; j < list.Count; j++)
            {
                Console.WriteLine(list[j]);
            }
            list.Reverse();
            Console.WriteLine("After Reverse");
            for (int k = 0; k < list.Count; k++)
            {
                Console.WriteLine(list[k]);
            }

        }
    }
}