using System;
using System.IO;

namespace TestConsole.day6
{
    public class MyWriteFile
    {

        public static void Run()
        {
            string input =
             "my input for writing file by C# programming language";

            File.WriteAllText("dotnet.txt", input);
            Console.WriteLine("เขียนไฟล์สำเร็จแล้วครับ");
        }
    }
}