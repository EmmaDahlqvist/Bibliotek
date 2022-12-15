using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Users
{
    internal class Librarian : User
    {
        public Librarian(string firstname, string lastname, string password, int number)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.password = password;
            this.number = number;
        }
    }
}
