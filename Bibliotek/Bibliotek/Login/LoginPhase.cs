using Bibliotek.Other;
using Bibliotek.TextFiles;
using Bibliotek.TextFiles.Login;
using Bibliotek.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Login
{
    internal class LoginPhase
    {
        Option1or2 option1Or2 = new Option1or2();
        CheckUser checkUser = new CheckUser();
        HandleTextFiles handleTextFiles = new HandleTextFiles();

        public User Login()
        {
            bool loginCorrect = false;
            User user;
            int loginAgain;
            do
            {
                Console.WriteLine("Är du\n1) Bibliotikare\n2) Medlem");
                int input = option1Or2.ChooseOption1Or2();

                Console.Write("Personnummer: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Lösenord: ");
                string password = Console.ReadLine();
                user = handleTextFiles.GetUser(input, password, number);

                loginCorrect = CheckAccountExistance(number, password, input);
                loginAgain = LoginAgain(loginCorrect);

            } while (loginAgain == 2);
            Console.WriteLine("out of loop");

            if(loginAgain == 1)
            {
                return user;
            } else if(loginAgain == 3)
            {
                return null;
            }

            return null;

        }

        private int LoginAgain(bool loginCorrect) //fel login -> skapa konto eller logga in igen
        {
            do
            {
                if (loginCorrect) //login var korrekt
                {
                    return 1;
                }
                else //två alternativ
                {
                    Console.WriteLine("1) Försök logga in igen\n2) Skapa konto");
                    int option = option1Or2.ChooseOption1Or2();
                    if (option == 1)
                    {
                        return 2; //försök igen
                    }
                    else if (option == 2)
                    {
                        return 3; //skapa konto o gå vidare
                    }
                }

            } while (!loginCorrect);
            return 0;
        }

        //kolla om loggin stämmer
        private bool CheckAccountExistance(int number, string password, int authority)
        {
            if (checkUser.CheckNumber(number, authority))
            {
                if (checkUser.CheckPassword(password, authority))
                {
                    Console.WriteLine("Välkommen in!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Felaktigt lösenord");
                }
            }
            else
            {
                Console.WriteLine("Detta personnummer är inte registrerat!");
            }

            return false;
        }
    }
}
