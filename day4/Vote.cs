using System;

namespace TestConsole.day4
{
    public class Vote
    {

        public static void Run()
        {
            int red = 0;
            int blue = 0;
            int green = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Vote for Red, Blue, Green (1/2/3): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        red++;
                        break;
                    case 2:
                        blue++;
                        break;
                    case 3:
                        green++;
                        break;
                }
            }
                Console.WriteLine("Red: {0} votes", red);
                Console.WriteLine("Blue: {0} votes", blue);
                Console.WriteLine("Green: {0} votes", green);
        }
    }
}
