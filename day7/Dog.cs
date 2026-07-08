using System;
namespace TestConsole.day7
{
    public class Dog
    {
        public string? name { get; set;}  //get อ่านได้เท่านั้น
        public int qtyOfLegs { get; set;} //get set อ่านและเขียนได้
        public string? color { get; set;} //get set อ่านและเขียนได้

        public void sayHi()
        {
            Console.WriteLine("Sey");
            Console.WriteLine("Hi");
        }

        public void sayHello(string message)
        {
            Console.WriteLine("Hello" + message);
        }

        public void addNumber(int x, int y)
        {
            int result = (x + y);
            Console.WriteLine("Result: {0}", result);
        }

    }
}