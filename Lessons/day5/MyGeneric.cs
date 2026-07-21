using System;

namespace TestConsole.day5
{
    class Dog
    {

    }
    public class MyGeneric
    {
        
        public static void Run()
        {
            List<Dog> list = new List<Dog>();
            list.Add(new Dog());
            list.Add(new Dog());
            list.Add(new Dog());

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Dog {0}", i);
            }
        }
    }
}