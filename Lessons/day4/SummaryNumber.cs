using System;

namespace TestConsole.day4
{
    public class SummaryNumber
    {

        public static void Run()
        {
            //ผลรวมของตัวเลขตั้งแต่ 1 ถึง 1000  = 500500
            int sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                sum += i;
            }
            Console.WriteLine("Sum = {0}", sum);
        }
    }
}