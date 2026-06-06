using System;
using System.IO;

namespace TestConsole.day6
{
    public class  MyAppendFile
    {

        public static void Run()
        {
            String target = "dotnet.txt";

            File.AppendAllText(target, "----------start------------\n");

           for (int i = 0; i < 10; i++)
            {
                File.AppendAllText(target, String.Format("Line {0}\n", i + 1));
            }
            Console.WriteLine("เขียนไฟล์สำเร็จแล้วครับ");
        }
    }
}