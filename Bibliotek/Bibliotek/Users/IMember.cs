using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Users
{
    internal interface IMember
    {
        void BorrowBook();
        void ReservBook();
        void ReturnBook();
    }
}
