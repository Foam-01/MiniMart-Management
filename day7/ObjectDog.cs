using System;
namespace TestConsole.day7
{
    public class ObjectDog
    {
        public static void Run()
        {
           Dog d = new Dog ();
           d.name = "Too";
           d.qtyOfLegs = 4;
           d.color = "Brown";

           Console.WriteLine("name = {0}, legs = {1}, color = {2}", d.name, d.qtyOfLegs, d.color);
        }
    }
}