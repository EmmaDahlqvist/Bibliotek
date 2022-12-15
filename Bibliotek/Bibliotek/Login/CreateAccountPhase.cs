using Bibliotek.Other;
using Bibliotek.TextFiles;
using Bibliotek.Users;

namespace Bibliotek.Login
{
    internal class CreateAccountPhase
    {
        Option1or2 option1Or2 = new Option1or2();
        CheckUser checkUser = new CheckUser();
        Inputs inputs = new Inputs();
        HandleTextFiles handleTextFiles = new HandleTextFiles();

        public User CreateAccount()
        {
            Console.WriteLine("Är du\n1) Bibliotikare\n2) Medlem");
            int input = option1Or2.ChooseOption1Or2();

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
                int choice = option1Or2.ChooseOption1Or2();

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
                handleTextFiles.AddLibrarian(user);
                return user;
            }
            else
            {
                User user = new Member(name, lastname, password, number);
                handleTextFiles.AddMember(user);
                return user;
            }
        }
    }
}
