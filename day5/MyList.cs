using System;

namespace TestConsole.day5
{
    public class MyList
    {

        public static void Run()
        {
           List<string> List = new List<string>();
            List.Add("Java");
            List.Add("C#");
            List.Add("Python");
            List.Add("JavaScript");
            List.Add("TypeScript");

            for (int i = 0; i < List.Count; i++)
            {
                Console.WriteLine(List[i]);
            }

                Console.WriteLine("=====================================");

            List.Remove("Python");
            Console.WriteLine("After Remove Python");
            for (int i = 0; i < List.Count; i++)
            {
                Console.WriteLine(List[i]);
            }
        }
    }
}