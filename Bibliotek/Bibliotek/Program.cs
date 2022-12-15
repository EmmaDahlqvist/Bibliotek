using Bibliotek.TextFiles;
using Bibliotek.TextFiles.Login;

namespace Bibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HandleTextFiles handleTextFiles = new HandleTextFiles();
            UserLogin login = new UserLogin();

            //Steg 1:
            //1) Logga in
            //2) Skapa konto
            login.LoginPhase();

            //Steg 2:
            //Meny
        }
    }
}