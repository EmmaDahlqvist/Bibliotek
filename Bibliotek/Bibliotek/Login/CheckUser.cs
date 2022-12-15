using Bibliotek.Other;
using Bibliotek.TextFiles;
using Bibliotek.TextFiles.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Login
{
    internal class CheckUser
    {
        HandleTextFiles handleTextFiles = new HandleTextFiles();

        public bool CheckPassword(string password, int authority)
        {
            return CheckUserInformation(2, password, authority);
        }

        public bool CheckNumber(int number, int authority)
        {
            return CheckUserInformation(2, number.ToString(), authority);
        }

        private bool CheckUserInformation(int partIndex, string part, int authority)
        {
            List<string> userList = new List<string>();
            if (authority == 1)
            {
                userList = handleTextFiles.GetLibrarians();
            }
            else if (authority == 2)
            {
                userList = handleTextFiles.GetMembers();
            }

            foreach (string user in userList)
            {
                string[] info = user.Split(" ");
                if (info.Length == 4)
                {
                    if (info[partIndex] == part)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
