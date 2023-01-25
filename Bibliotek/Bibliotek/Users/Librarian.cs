using Bibliotek.Books;
using Bibliotek.Other;
using Bibliotek.TextFiles;
using System.Xml.Linq;

namespace Bibliotek.Users
{
    internal class Librarian : User, ILibrarian
    {
        HandleBookFiles handleBookFiles = new HandleBookFiles();
        HandleUserFiles handleUserFiles = new HandleUserFiles();
        ChooseOption chooseOption = new ChooseOption();

        public Librarian(string firstname, string lastname, string password, int number)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.password = password;
            this.number = number;
        }

        public void BookStage()
        {
            Console.Clear();
            Console.WriteLine("1) Lägg till bok\n2) Ta bort bok\n3) Sök efter bok");
            switch (chooseOption.ThreeOption())
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    RemoveBook();
                    break;
                case 3:
                    SearchBook();
                    break;
            }

        }

        public void UserStage()
        {
            Console.Clear();
            Console.WriteLine("1) Se användarlistan\n2) Lägg till användare\n3) Ta bort användare\n4) Redigera användare (Kommer snart)");
            switch (chooseOption.ThreeOption())
            {
                case 1:
                    UsersList();
                    break;
                case 2:
                    AddUser();
                    break;
                case 3:
                    RemoveUser();
                    break;
            }
        }

        public void AddBook()
        {
            Console.Clear();
            Console.WriteLine("Vilken bok vill du lägga till? [Titel, Författare, ISBN]");
            Console.Write("Titel: ");
            string title = Console.ReadLine();
            Console.Write("Författare: ");
            string author = Console.ReadLine();
            Console.Write("ISBN: ");
            string ISBN = Console.ReadLine();
            Book book = new Book(title, author, ISBN);

            Console.WriteLine(title + " tillagd!");

            handleBookFiles.AddBook(book, "A", 0); //lägg till bok
        }

        public void AddUser()
        {
            Console.Clear();
            Console.WriteLine("Lägg till användare: [Förnamn, Efternamn, Lösenord, Personnummer]");
            Console.Write("Förnamn: ");
            string name = Console.ReadLine();
            Console.Write("Efternamn: ");
            string lastname = Console.ReadLine();
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();
            Console.Write("Personnummer: ");
            int number = int.Parse(Console.ReadLine());
            User user = new Member(name, lastname, password, number);

            Console.WriteLine(name + " " + lastname + " tillagd!");

            handleUserFiles.AddMember(user); //lägg till användare (endast members)
        }

        public void RemoveBook()
        {
            Console.Clear();
            Console.Write("Vilken bok vill du ta bort? Ange författare, titel eller ISBN: ");
            string info = Console.ReadLine();
            List<Book> book = handleBookFiles.SearchBook(info);

            while(book.Count == 0)
            {
                Console.WriteLine("Boken hittades inte! Försök igen eller avbryt [avbryt]");
                info = Console.ReadLine();
                if(info != "avbryt")
                {
                    book = handleBookFiles.SearchBook(info);
                } else
                {
                    break;
                }
            }

            for(int i = 0; i < book.Count; i++)
            {
                Console.WriteLine("Book found");
                string status = handleBookFiles.GetBookStatus(book[i]);
                Console.WriteLine(status);
                if (status == "A") //ta bort första boken som inte är utlånad / reserverad
                {
                    Console.WriteLine("Tog bort boken " + book[i].name);
                    handleBookFiles.RemoveBook(book[i], "A", 0);
                    break;
                }
            }
        }

        public void RemoveUser()
        {
            Console.Clear();
            Console.Write("Vilken användare vill du ta bort? Ange personnummer: ");
            int number = int.Parse(Console.ReadLine());
            User user = handleUserFiles.SearchMember(number);
            while (user == null)
            {
                Console.WriteLine("Användaren hittades inte! Försök igen eller avbryt [-1]");
                number = int.Parse(Console.ReadLine());
                if (number != -1)
                {
                    user = handleUserFiles.SearchMember(number);
                }
                else
                {
                    break;
                }
            }

            if(user != null)
            {
                Console.WriteLine("Tog bort " + user.firstname + " " + user.lastname);
                handleUserFiles.RemoveMember(user);
            }
        }

        public void UsersList()
        {
            List<string> members = handleUserFiles.GetMembers();
            for(int i = 0; i < members.Count; i++)
            {
                string[] memberInfo = members[i].Split("|");
                if(memberInfo.Length == 4)
                {
                    Console.WriteLine(memberInfo[0] + " " + memberInfo[1] + " " + memberInfo[2] + " " + memberInfo[3]);
                }
            }
        }
    }
}
