using System;
namespace TestConsole.day8
{
    public class AuthorModal
    {
        public int id { get; set;}
        public string? name { get; set;}
        
        public AuthorModal()
        {
        }
        public AuthorModal(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}