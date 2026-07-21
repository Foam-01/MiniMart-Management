using System;

namespace TestConsole.day6
{
    public class MyDate
    {

        public static void Run()
        {
           DateTime myDateTime = DateTime.Now;
           Console.WriteLine(myDateTime.Year);
              Console.WriteLine(myDateTime.Month);
                 Console.WriteLine(myDateTime.Day);
                    Console.WriteLine(myDateTime.Hour);
                       Console.WriteLine(myDateTime.Minute);
                          Console.WriteLine(myDateTime.Second); 
        }
    }
}