using Bibliotek.Books;
using Bibliotek.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.TextFiles
{
    internal class HandleUserFiles
    {
        public void AddLibrarian(User user)
        {
            AddUser(user, "C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Librarians.txt");
        }

        public List<String> GetLibrarians()
        {
            return GetUsers("C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Librarians.txt");
        }

        public void AddMember(User user)
        {
            AddUser(user, "C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Members.txt");
        }

        public List<String> GetMembers()
        {
            return GetUsers("C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Members.txt");
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
                Console.WriteLine("Getting members");
                userList = GetMembers();
            }

            foreach (string user in userList)
            {

                string[] info = user.Split("|");
                if (info.Length == 4)
                {
                    if (info[3] == password)
                    {
                        if (info[2] == number.ToString())
                        {

                            if (authority == 1)
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

        //sök efter member (för bibliotikarier)
        public User SearchMember(int number) //sök utifrån personnummer
        {
            User user = null;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Members.txt");
                string ln;
                int counter = 0;
                while ((ln = sr.ReadLine()) != null)
                {
                    string[] lnSplit = ln.Split("|");
                    if (lnSplit.Length == 4) //fyra giltliga argument
                    {
                        if (lnSplit[3] == number.ToString())
                        {
                            user = new Member(lnSplit[0], lnSplit[1], lnSplit[2], int.Parse(lnSplit[3]));
                        }
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return user;
        }

        public void RemoveMember(User member)
        {
            string memberString = member.firstname + "|" + member.lastname + "|" + member.number + "|" + member.password;
            try
            {
                string file = "C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Members.txt";
                
                // spara allt i filen
                string[] readText = File.ReadAllLines(file);

                // töm filen
                File.WriteAllText(file, String.Empty);

                // lägg till alla members förutom den som ska bort
                using (StreamWriter writer = new StreamWriter(file))
                {
                    foreach (string s in readText)
                    {
                        if (!s.Equals(memberString))
                        {
                            writer.WriteLine(s);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private void AddUser(User input, string file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file, true);
                sw.WriteLine(input.firstname + "|" + input.lastname + "|" + input.number + "|" + input.password);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public List<String> GetUsers(string file)
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
