using Bibliotek.TextFiles;
using Bibliotek.TextFiles.Login;
using Bibliotek.Users;
using Bibliotek.Books;
using Bibliotek.Other;

namespace Bibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HandleUserFiles handleUserFiles = new HandleUserFiles();
            UserLogin login = new UserLogin();
            ChooseOption options = new ChooseOption();

            //Steg 1:
            //1) Logga in
            //2) Skapa konto
            User activeUser = login.LoginPhase();
            Console.WriteLine("Välkommen in " + activeUser.firstname + " " + activeUser.lastname + "!");

            if(activeUser is Librarian) //bibliotikarie
            {
                Console.Clear();
                Librarian librarian = new Librarian(activeUser.firstname, activeUser.lastname, activeUser.password, activeUser.number);
                Console.WriteLine("1) Hantera böcker\n2) Hantera användare\n3) Hantera ditt konto (Kommer snart)");
                int option = options.ThreeOption();
                switch (option)
                {
                    case 1:
                        librarian.BookStage();
                        break;
                    case 2:
                        librarian.RemoveUser();
                        break;
                }

            } else if(activeUser is Member) //member
            {
                Console.Clear();
                Member member = new Member(activeUser.firstname, activeUser.lastname, activeUser.password, activeUser.number);
                Console.WriteLine("1) Böcker\n2) Byt lösenord");
                int option = options.TwoOption();
                switch (option)
                {
                    case 1:
                        member.BookStage(member);
                        break;
                    case 2:
                        member.ChangePassword(member);
                        break;

                }
            }

            //Steg 2:
            //Meny
        }
    }
}