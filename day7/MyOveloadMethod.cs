using System;
namespace TestConsole.day7
{
    public class MyOverloadMethod
    {
        public MyOverloadMethod()
        {
            hello();
            hello("Foam");
            hello(24);
        }
        public void hello()
        {
            Console.WriteLine("Hello");
        }

        public void hello(string name)
        {
            Console.WriteLine("Hello " + name);
        }

        public void hello(int age)
        {
            Console.WriteLine("Hello " + age);
        }
    }
}