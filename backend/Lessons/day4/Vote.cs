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
                string input = Console.ReadLine() ?? "0";
                if (!int.TryParse(input, out int choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid vote! Please choose 1, 2, or 3.");
                    i--;
                    continue;
                }

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
