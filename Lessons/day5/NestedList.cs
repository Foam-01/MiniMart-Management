using System;

namespace TestConsole.day5
{
    public class NestedList
    {

        public static void Run()
        {
            List<List<string>> list = new List<List<string>>();
            List<string> Mylist = new List<string>();
            Mylist.Add("Java");
            Mylist.Add("C#");
            Mylist.Add("Python");
            Mylist.Add("JavaScript");
            Mylist.Add("TypeScript");

            list.Add(Mylist);

            for (int i = 0; i < list.Count; i++)
            {
                List<string> value = list[i];

                for (int j = 0; j < value.Count; j++)
                {
                    Console.WriteLine(value[j]);
                }
            }

        }
    }
}