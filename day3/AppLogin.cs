using System;

namespace TestConsole.day3
{
    public class AppLogin
    {

        public static void Run()
        {
            string? username;
            string? password;

            Console.WriteLine("Enter username:");
            username = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Enter password:");
            password = Console.ReadLine(); 

            if (username == "admin" && password == "1234")
            {
                Console.WriteLine("Successfully logged in");
            } else
            {
                Console.WriteLine("Login Fail");
            }
        }
    }
}