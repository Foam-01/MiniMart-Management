using System;
using TestConsole.day6;

namespace TestConsole.day7
{
    public class MyObject
    {
        public static void Run()
        {
            Book book = new Book(); // object
            Book b;                 // instance  != object
            b = new Book();

            Console.WriteLine(book);
            Console.WriteLine(b);   // object of class Book
        }
    }
}