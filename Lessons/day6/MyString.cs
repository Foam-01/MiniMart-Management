using System;

namespace TestConsole.day6
{
    public class MyString
    {

        public static void Run()
        {
            String str = "Hello World";

            Console.WriteLine(str.StartsWith("H"));
            Console.WriteLine(str.EndsWith("d"));
            Console.WriteLine(str.Contains("o W"));
            Console.WriteLine(str.IndexOf("o"));
            Console.WriteLine(str.LastIndexOf("o"));
            Console.WriteLine(str.Substring(6, 5));
            Console.WriteLine(str.Length);

        }
    }
}