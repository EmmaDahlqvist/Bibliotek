using Bibliotek.Books;
using Bibliotek.TextFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Users
{
    internal class User : IUsers
    {
        HandleBookFiles handleBookFiles = new HandleBookFiles();

        public string firstname;
        public string lastname;
        public string password;
        public int number;

        public void SearchBook()
        {
            Console.WriteLine("Sök bok utifrån författare, titel eller ISBN:");
            string info = Console.ReadLine();
            handleBookFiles.SearchBook(info);
        }

        public Book AskForBook()
        {
            Console.Write("Titel: ");
            string title = Console.ReadLine();
            Console.Write("Författare: ");
            string author = Console.ReadLine();
            Console.Write("ISBN: ");
            string ISBN = Console.ReadLine();
            Book book = new Book(title, author, ISBN);

            return book;
        }

        public void HandleAccount()
        {

        }
    }
}
