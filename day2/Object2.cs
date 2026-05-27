using System;

namespace TestConsole.day2
{
    public class Object2
    {
        // เปลี่ยนจาก public Object2() เป็น public static void Run()
        public static void Run()
        {
            object obj = new
            {
                name = "ASUS",
                age = 20,
                salary = 2000000
            };
            Console.WriteLine(obj);
        }
    }
}