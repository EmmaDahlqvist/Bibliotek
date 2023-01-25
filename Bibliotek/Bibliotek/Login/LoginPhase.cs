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
        ChooseOption options = new ChooseOption();
        CheckUser checkUser = new CheckUser();
        HandleUserFiles handleUserFiles = new HandleUserFiles();

        public User Login()
        {
            bool loginCorrect = false;
            User user;
            int loginAgain;

            do
            {
                Console.WriteLine("Är du\n1) Bibliotikare\n2) Medlem");
                int input = options.TwoOption();

                Console.Write("Personnummer: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Lösenord: ");
                string password = Console.ReadLine();
                user = handleUserFiles.GetUser(input, password, number);
                if(user == null)
                {
                    Console.WriteLine("Användare fanns ej! Försök logga in igen!");
                    loginAgain = 2;
                } else
                {
                    loginAgain = 1;
                }

                //loginCorrect = CheckAccountExistance(number, password, input);
                //loginAgain = LoginAgain(loginCorrect);

            } while (loginAgain == 2);

            if(loginAgain == 1)
            {
                if(user == null)
                {
                    Console.WriteLine("null");
                }
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
                    int option = options.TwoOption();
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
                    //rätt lösen och rätt personnummer
                    Console.WriteLine("Correct info");
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
