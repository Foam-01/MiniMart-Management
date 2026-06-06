using System;
using System.Text;

namespace TestConsole.day6
{
    public class StringFormatAndStringBuilder
    {

        public static void Run()
        {
            string str = String.Format
            ("Hello {0} My name is {1}", "World", "GIGABYTE");

            StringBuilder myStringBuilder = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                myStringBuilder.AppendLine(String.Format("Line {0}\n", i + 1));
            }
            Console.WriteLine(myStringBuilder.ToString());
        }
    }
}