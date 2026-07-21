using System;
using System.IO;

namespace TestConsole.day6
{
    public class  ReadDir
    {

        public static void Run()
        {
            // c: , d;
            // /home, /var , /
            string[] dirs = Directory.GetDirectories(@"D:\");

            foreach (string dir in dirs) {
                Console.WriteLine(dir);
            }
        }
    }
}