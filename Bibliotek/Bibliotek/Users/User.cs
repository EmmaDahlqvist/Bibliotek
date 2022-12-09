using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Users
{
    internal class User : IUsers
    {
        public string firstname;
        public string lastname;
        public string password;
        public int number;

        public void CreateUserAccount()
        {
            Console.Write("Namn: ");
            string name = Console.ReadLine();

            Console.Write("Efternamn: ");
            string lastname = Console.ReadLine();

            Console.Write("Lösenord: ");
            string password = Console.ReadLine();

            Console.Write("Personnummer: ");
            int number = int.Parse(Console.ReadLine());
        }
    }
}
