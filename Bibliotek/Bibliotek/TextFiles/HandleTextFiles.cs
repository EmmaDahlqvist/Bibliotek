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
        public void AddLibrarian(string input)
        {
            AddUser(input, "C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Librarians.txt");
        }

        public List<String> GetLibrarians()
        {
            return GetUser("C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Librarians.txt");
        }

        public void AddMember(string input)
        {
            AddUser(input, "C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Members.txt");
        }

        public List<String> GetMember(string input)
        {
            return GetUser("C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Members.txt");
        }
        
        
        
        
        private void AddUser(string input, string file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file, true);
                sw.WriteLine(input);
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
                    Console.WriteLine(ln);
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
