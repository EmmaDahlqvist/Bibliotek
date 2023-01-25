using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Books
{
    internal class Book
    {
        public string name;
        public string author;
        public string ISBN;

        public Book(string name, string author, string ISBN)
        {
            this.name = name;
            this.author = author;
            this.ISBN = ISBN;
        }
    }
}
