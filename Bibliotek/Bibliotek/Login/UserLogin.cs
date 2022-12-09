using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.TextFiles.Login
{
    internal class UserLogin
    {
        public void Login()
        {
            Console.WriteLine("Välkommen!");
            Console.WriteLine("1) Logga in\n2) Skapa konto");
            int input;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if(input == 1 || input == 2)
                    {
                        break;
                    } else
                    {
                        Console.WriteLine("Välj alternativ 1 eller 2!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Välj alternativ 1 eller 2!");
                }

            } while (true);

            if(input == 1)
            {
                //login
            } else if(input == 2)
            {
                //createAccount
            }
        }
    }
}
