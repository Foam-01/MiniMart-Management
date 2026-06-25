using System;

namespace TestConsole.day6
{
    public class ReadFileList
    {

        public static void Run()
        {
            DirectoryInfo dirs = new DirectoryInfo(@"D:\Git Desktop");
            FileInfo[] files = dirs.GetFiles("*");

            foreach (FileInfo file in files)
            {
                string name = file.Name;
                long size = file.Length;

                Console.WriteLine(string.Format("{0}t\t{1}", size, name));
            }
        }
    }
}