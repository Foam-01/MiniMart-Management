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
            } else if (score >= 50 && score < 55)
            {
                Console.WriteLine("Your grade is D");
            } else if (score >= 55 && score < 60)
            {
                Console.WriteLine("Your grade is D+");
            } else if (score >= 60 && score < 65)
            {
                Console.WriteLine("Your grade is C");
            } else if (score >= 65 && score < 70)
            {
                Console.WriteLine("Your grade is C+");
            } else if (score >= 70 && score < 75)
            {
                Console.WriteLine("Your grade is B");
            } else if (score >= 75 && score < 80)
            {
                Console.WriteLine("Your grade is B+");
            } else if (score >= 80 && score <= 100)
            {
                Console.WriteLine("Your grade is A");
            } else 
            {
                Console.WriteLine("Invalid score");
            }
        }
    }
}