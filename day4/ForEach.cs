using System;

namespace TestConsole.day4
{
    public class ForEach
    {

        public static void Run()
        {
            string [] names = { "โฟม", "อลิส", "ปอง" };
            foreach (string name in names)
            {
                Console.WriteLine("name: " + name);
            }

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("name: " + names[i]);
            }
        }
    }
}