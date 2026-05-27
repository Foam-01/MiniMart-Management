using System;

namespace TestConsole.day2
{
    public class Object3
    {
        // เปลี่ยนจาก public Object2() เป็น public static void Run()
        public static void Run()
        {
            object obj = new
            {
                info = new
                {
                    name = "ASUS",
                    age = 24,
                    salary = 15000
                },
                skill = new
                {
                    skill1 = "C#",
                    skill2 = "Java",
                    skill3 = "Python"
                },
                title = "Info of Foam"
            };
           
            Console.WriteLine(obj);
        }
    }
}