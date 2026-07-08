using System;
namespace TestConsole.day7
{
    public class Box
    {
        public Box()
        {
            int result =  addNumber(5, 10);
            Console.WriteLine("Result: {0}", result);
        }
        public int addNumber(int x, int y )
        {
            return (x + y);
        }
    }
}