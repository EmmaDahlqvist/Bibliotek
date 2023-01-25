using Bibliotek.Books;
using Bibliotek.Other;
using Bibliotek.TextFiles;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Users
{
    internal class Member : User
    {
        ChooseOption chooseOption = new ChooseOption();
        HandleBookFiles handleBookFiles = new HandleBookFiles();
        HandleUserFiles handleUserFiles = new HandleUserFiles();
        public Member(string firstname, string lastname, string password, int number)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.password = password;
            this.number = number;
        }

        public void BookStage(Member member)
        {
            Console.Clear();
            bool repeat = false;
            do
            {
                Console.WriteLine("1) Sök bok\n2) Lämna tillbaka bok\n3) Låna bok\n4) Reservera bok");
                switch (chooseOption.OptionAmount(4))
                {
                    case 1:
                        SearchBook(); //sök i boklistan, gör sedan något annat
                        repeat = true;
                        break;
                    case 2:
                        ReturnBook(member); //lämna tillbaks
                        break;
                    case 3:
                        ReservOrBorrow("B", member); //låna
                        break;
                    case 4:
                        ReservOrBorrow("R", member); //reservera
                        break;

                }
            } while (true);
        }

        public void ChangePassword(Member member)
        {
            Console.Clear();
            Console.Write("Nytt lösenord: ");
            string password = Console.ReadLine();

            //skapa ny temp member
            User tempMember = new Member(member.firstname, member.lastname, password, member.number);

            //ta bort gammal member
            handleUserFiles.RemoveMember(member);

            //lägg till ny member
            handleUserFiles.AddMember(tempMember);
        }

        private void ReturnBook(Member member)
        {
            Console.Clear();
            Console.WriteLine("Vilken bok vill du lämna tillbaka?");
            Console.WriteLine("Dina lånade böcker är:");
            List<Book> books = handleBookFiles.SearchBook(member.number.ToString());
            foreach (Book ownedBook in books)
            {
                Console.WriteLine(ownedBook.name);
            }

            Book book = member.AskForBook();

            if(handleBookFiles.GetBookOwner(book) == member.number.ToString())
            {
                handleBookFiles.RemoveBook(book, "B", member.number); //ta bort den lånade
                handleBookFiles.AddBook(book, "A", 0); //lägg till den igen som tillgänglig
            }
        }

        private bool ReservOrBorrow(string status, Member member)
        {
            Console.Clear();
            do
            {
                Book book = member.AskForBook();


                if (handleBookFiles.GetBookStatus(book) == "A")
                {
                    Console.WriteLine("Reserverade boken " + book.name);
                    handleBookFiles.AddBook(book, status, member.number);
                    handleBookFiles.RemoveBook(book, "A", 0);
                    return true;
                }
                else
                {
                    Console.WriteLine("Vald bok är inte tillgänglig, vänligen försök igen!");
                }
            } while (true);
        }
    }
}
