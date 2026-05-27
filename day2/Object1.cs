using System;

namespace TestConsole.day2
{
    public class Object1
    {
        // เปลี่ยนจาก public Object1() เป็น public static void Run()
        public static void Run()
        {
            object obj;

            obj = new
            {
                name = "GIGABYTE",
                age = 1,
                salary = 1000000
            };

            Console.WriteLine(obj);
        }
    }
}