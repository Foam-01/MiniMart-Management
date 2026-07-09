using System;
namespace TestConsole.day7
{
    public class Cat : Animal
    {
        public int eye;
        public Cat()
        {
        }
        new public void echo()
        {
            Console.WriteLine("Meow Meow");
        }
    }
}