using System;
namespace TestConsole.day8
{
    public class BookModel
    {
        public int id { get; set;}
        public string? isbn { get; set;}
        public string? name { get; set;}
        
        public AuthorModal? author { get; set;}

    }
}