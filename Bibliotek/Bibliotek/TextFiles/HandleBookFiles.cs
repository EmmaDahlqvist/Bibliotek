using Bibliotek.Books;

namespace Bibliotek.TextFiles
{
    internal class HandleBookFiles
    {
        //där alla böcker sparas
        private string avalibleBooksFile = "C:\\Users\\emma.dahlqvist4\\Desktop\\Bibliotek\\Bibliotek\\Bibliotek\\TextFiles\\Books.txt";
       
        //för bibiliotikarier och medlemmar
        public List<Book> SearchBook(string info) //info kan vara namn, författare, eller ISBN, personnummer, eller vilka som är utlånade
        {
            Console.Clear();
            Book book = null;
            List<Book> books = new List<Book>();
            try
            {
                StreamReader sr = new StreamReader(avalibleBooksFile);
                string ln;
                int counter = 0;

                while ((ln = sr.ReadLine()) != null)
                {
                    string[] lnSplit = ln.Split("|");
                    if(lnSplit.Length == 5) //tre giltliga argument
                    {
                        for (int i = 0; i < lnSplit.Length; i++)
                        {
                            if (lnSplit[i] == info)
                            {
                                string status = "";
                                string user = "";
                                book = new Book(lnSplit[0], lnSplit[1], lnSplit[2]);
                                books.Add(book);
                                
                                if (lnSplit[3] == "A")
                                {
                                    status = "Ej utlånad";
                                    user = "";
                                } else if (lnSplit[3] == "R")
                                {
                                    status = "Reserverad av";
                                    user = "(Personnummer) " + lnSplit[4];
                                } else if (lnSplit[3] == "B")
                                {
                                    status = "Utlånad till";
                                    user = "(Personnummer) " + lnSplit[4];
                                }
                                Console.WriteLine(book.name + " " + book.author + " " + book.ISBN + " - " + status + " " + user);
                            }
                        }
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return books;
        }

        public string GetBookStatus(Book book)
        {
            return GetBookInfo(book, "status");
        }

        public string GetBookOwner(Book book)
        {
            return GetBookInfo(book, "number");
        }

        public string GetBookInfo(Book book, string statusOrNumber)
        {
            string[] bookInfo = new string[] { book.name, book.author, book.ISBN };
            string info = null; //standard att boken inte finns

            try
            {
                StreamReader sr = new StreamReader(avalibleBooksFile);
                string ln;
                int counter = 0;
                while ((ln = sr.ReadLine()) != null)
                {
                    string[] lnSplit = ln.Split("|");
                    if (lnSplit.Length == 5)
                    {
                        //se om boken finns
                        if (bookInfo[0] == lnSplit[0] && bookInfo[1] == lnSplit[1] && bookInfo[2] == lnSplit[2])
                        {

                            if(statusOrNumber == "status")
                            {
                                info = lnSplit[3]; //returnera statusen på boken, "A", "R", "B",
                                break; //ta första bästa boken eftersom det kan finnas flera
                            } else if(statusOrNumber == "number")
                            {
                                info = lnSplit[4]; //returnera personnummret på den som har lånat boken
                                break; //ta första bästa boken eftersom det kan finnas flera
                            }
                        }
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {

            }
            Console.WriteLine("INFO: " + info);
            return info;
        }
        
        //endast för bibliotikarier
        public void AddBook(Book book, string status, int number)
        {
            string name = book.name;
            string author = book.author;
            string ISBN = book.ISBN;
            try {
            
                StreamWriter sw = new StreamWriter(avalibleBooksFile, true);
                sw.WriteLine(name + "|" + author + "|" + ISBN + "|" + status + "|" + number.ToString());
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        //endast för bibliotikarier
        public void RemoveBook(Book bookToRemove, string status, int number)
        {
            string bookToRemoveString = bookToRemove.name + "|" + bookToRemove.author + "|" + bookToRemove.ISBN + "|" + status + "|" + number;
            try
            {
                // spara allt i filen
                string[] readText = File.ReadAllLines(avalibleBooksFile);
                // töm filen
                File.WriteAllText(avalibleBooksFile, String.Empty);

                // lägg till allt förutom boken som ska bort
                using (StreamWriter writer = new StreamWriter(avalibleBooksFile))
                {
                    int amountOfRemovedBooks = 0; // ta bara bort en bok
                    foreach (string s in readText)
                    {
                        if (!s.Equals(bookToRemoveString) || amountOfRemovedBooks == 1)
                        {
                            writer.WriteLine(s);
                        } else
                        {
                            amountOfRemovedBooks = 1;
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
