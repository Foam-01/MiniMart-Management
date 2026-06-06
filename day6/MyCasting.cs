using System;

namespace TestConsole.day6
{
    public class MyCasting
    {

        public static void Run()
        {
           string str1 = "10";
           string str2 = "32";
           string b = "True";

           int str3 = Convert.ToInt32(str1) + Convert.ToInt32(str2);

            string output = "str3 = " + str3.ToString();

           Console.WriteLine(output);
           bool str4 = Convert.ToBoolean(b);
           Console.WriteLine(str4);  
        }
    }
}