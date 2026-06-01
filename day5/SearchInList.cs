using System;

namespace TestConsole.day5
{
    public class SearchInList
    {

        public static void Run()
        {
            List<string> list = new List<string>();
            list.Add("Hello");
            list.Add("World");
            list.Add("C#");
            list.Add("Programming");

            string value1 = list.Find(item => item.StartsWith("H"))!;
            Console.WriteLine("===============================");
            Console.WriteLine("Starts with 'H': " + value1);

            Console.WriteLine("===============================");
            List<string> valuesWithO = list.FindAll(item => item.Contains("o"));
            for (int i = 0; i < valuesWithO.Count; i++)
            {
                Console.WriteLine("Contains 'o': " + valuesWithO[i]);
            }
        }
    }
}