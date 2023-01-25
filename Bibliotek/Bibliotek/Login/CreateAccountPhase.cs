using Bibliotek.Other;
using Bibliotek.TextFiles;
using Bibliotek.Users;

namespace Bibliotek.Login
{
    internal class CreateAccountPhase
    {
        ChooseOption options = new ChooseOption();
        CheckUser checkUser = new CheckUser();
        Inputs inputs = new Inputs();
        HandleUserFiles handleUserFiles = new HandleUserFiles();

        public User CreateAccount()
        {
            Console.WriteLine("Är du\n1) Bibliotikare\n2) Medlem");
            int input = options.TwoOption();

            Console.Write("Namn: ");
            string name = Console.ReadLine();

            Console.Write("Efternamn: ");
            string lastname = Console.ReadLine();

            Console.Write("Lösenord: ");
            string password = Console.ReadLine();

            Console.Write("Personnummer: ");
            int number = inputs.ForceIntInput();

            while (checkUser.CheckNumber(number, input))
            {
                Console.WriteLine("Detta personnummer är redan registrerat! Vänligen:");
                Console.WriteLine("1) Skriv in ett annat \n2) Logga in");
                int choice = options.TwoOption();

                if (choice == 1)
                {
                    Console.Write("Personnummer: ");
                    number = inputs.ForceIntInput();
                }
                else if (choice == 2)
                {
                    return null;
                }
            }

            if (input == 1)
            {
                User user = new Librarian(name, lastname, password, number);
                handleUserFiles.AddLibrarian(user);
                return user;
            }
            else
            {
                User user = new Member(name, lastname, password, number);
                handleUserFiles.AddMember(user);
                return user;
            }
        }
    }
}
