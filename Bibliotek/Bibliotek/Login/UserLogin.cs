using Bibliotek.Login;
using Bibliotek.Other;
using Bibliotek.Users;

namespace Bibliotek.TextFiles.Login
{
    internal class UserLogin
    {
        Option1or2 option1or2 = new Option1or2();
        LoginPhase login = new LoginPhase();
        CreateAccountPhase createAccount = new CreateAccountPhase();
        public void LoginPhase()
        {
            Console.WriteLine("Välkommen!");
            Console.WriteLine("1) Logga in\n2) Skapa konto");
            int input = option1or2.ChooseOption1Or2();

            if(input == 1)
            {
                Login();

            } else if(input == 2)
            {
                CreateAccount();
            }
        }

        private void Login()
        {
            if (login.Login() == null) //inloggningen gick inte igenom
            {
                CreateAccount();
            } 
        }

        private void CreateAccount() {
            if (createAccount.CreateAccount() == null)
            {
                Login();
            }
        }

    }
}