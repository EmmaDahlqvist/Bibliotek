using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Users
{
    internal interface ILibrarian
    {
        void AddBook();
        void RemoveBook();
        void UsersList();
        void AddUser();
        void RemoveUser();
    }
}
