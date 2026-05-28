using System;

namespace TestConsole.day3
{
    public class AppGrade
    {

        public static void Run()
        {
           int score = 0;

           Console.WriteLine("Enter your score: ");
           score =  Convert.ToInt32(Console.ReadLine());

           if (score < 50)
            {
                Console.WriteLine("Your grade is F");
            } else if (score <= 60)
            {
                Console.WriteLine("Your grade is D");
            } else if (score <= 70)
            {
                Console.WriteLine("Your grade is C");
            } else if (score <= 80)
            {
                Console.WriteLine("Your grade is B");
            } else
            {
                Console.WriteLine("Your grade is A");
            }
        }
    }
}