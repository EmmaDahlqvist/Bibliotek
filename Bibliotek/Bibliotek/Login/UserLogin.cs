using Bibliotek.Login;
using Bibliotek.Other;
using Bibliotek.Users;

namespace Bibliotek.TextFiles.Login
{
    internal class UserLogin
    {
        ChooseOption option1or2 = new ChooseOption();
        LoginPhase login = new LoginPhase();
        CreateAccountPhase createAccount = new CreateAccountPhase();
        public User LoginPhase()
        {
            Console.WriteLine("Välkommen!");
            Console.WriteLine("1) Logga in\n2) Skapa konto");
            int input = option1or2.TwoOption();
            User user = null;

            if(input == 1)
            {
                user = Login();

            } else if(input == 2)
            {
                user = CreateAccount();
            }

            return user;
        }

        private User Login()
        {
            User user = login.Login();
            if (user == null) //inloggningen gick inte igenom
            {
                Console.WriteLine("användare fanns ej");
                CreateAccount();
            }

            return user;
        }

        private User CreateAccount() {
            User user = createAccount.CreateAccount();
            if (user == null)
            {
                Login();
            }

            return user;
        }

    }
}