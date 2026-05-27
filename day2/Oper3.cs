using System;
namespace TestConsole.day2
{
    public class Oper3
    {
        public Oper3()
        {
            int x = 5;

            Console.WriteLine(x += 5); //x = x + 5 = 10
            Console.WriteLine(x -= 5); //x = x - 5 = 5
            Console.WriteLine(x *= 5); //x = x * 5 = 25
            Console.WriteLine(x /= 5); //x = x / 5 = 5
            Console.WriteLine(x %= 5); //x = x % 5 = 0
        }
    }
}