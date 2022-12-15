using Bibliotek.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.TextFiles
{
    internal class HandleTextFiles
    {
        public void AddLibrarian(User user)
        {
            AddUser(user, "C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Librarians.txt");
        }

        public List<String> GetLibrarians()
        {
            return GetUser("C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Librarians.txt");
        }

        public void AddMember(User user)
        {
            AddUser(user, "C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Members.txt");
        }

        public List<String> GetMembers()
        {
            return GetUser("C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Members.txt");
        }

        public User GetUser(int authority, string password, int number)
        {
            List<string> userList = new List<string>();
            if (authority == 1)
            {
                userList = GetLibrarians();
            }
            else if (authority == 2)
            {
                userList = GetMembers();
            }

            foreach (string user in userList)
            {
                string[] info = user.Split(" ");
                if (info.Length == 4)
                {
                    if (info[2] == password)
                    {
                        if (info[3] == number.ToString())
                        {
                            if(authority == 1)
                            {
                                return new Librarian(info[0], info[1], info[2], int.Parse(info[3]));
                            } else if (authority == 2){
                                return new Member(info[0], info[1], info[2], int.Parse(info[3]));
                            }
                        }
                    }
                }
            }

            return null;

        }

        private void AddUser(User input, string file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file, true);
                sw.WriteLine(input.firstname + " " + input.lastname + " " + input.number + " " + input.password);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private List<String> GetUser(string file)
        {
            List<string> members = new List<string>();
            String line;
            try
            {
                StreamReader sr = new StreamReader(file);
                int counter = 0;
                string ln;

                while ((ln = sr.ReadLine()) != null)
                {
                    members.Add(ln);
                    counter++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return members;
        }
    }
}
