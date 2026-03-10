namespace Library
{
    class Library
    {
        public int bookId {  get; set; }
        public string titleName { get; set; }
        public string authorName { get; set; }  
        public string genre { get; set; }
        public bool isAvailable { get; set; }
        public double price { get; set; }

        public static List<Library> Retrive()
        {
            List<Library> list = new List<Library>()
            {
                new Library() {bookId = 101, titleName = "C++",authorName =  "Pawan",genre =  "Coding",isAvailable = true,price= 1000.10 },

                new Library() {bookId = 102, titleName = "C#",authorName =  "Sanjay",genre =  "Coding",isAvailable = true,price= 1010.10 }
            }; 

            return list;

        }

        public static void AddBook(Library newBook, List<Library> list)
        {
            list.Add(newBook);
        }

        public static Library SearchBook(string foundTitleName, List<Library> list)
        {
            Library foundBook = null;

            foreach (Library book in list)
            {
                if (book.titleName == foundTitleName)
                {
                    foundBook = book;
                    break;
                }
            }
            return foundBook;
        }
        public static List<Library> SearchAllBook(string foundTitleName, List<Library> list)
        {
            List<Library> foundBookList = new List<Library>();

            foreach (Library book in list)
            {
                if (book.titleName == foundTitleName)
                {
                    foundBookList.Add(book);
                }
            }
            return foundBookList;
        }

        public static List<Library> availableBooks(List<Library> list)
        {
            List<Library> foundedBooks = new List<Library>();
            foreach(Library book in list)
            {
                if(book.isAvailable == true)
                {
                    foundedBooks.Add(book);
                }
            }

            return foundedBooks;
        }

        public static void removeUnavailableBooks(List<Library> list) {

            for(int i = list.Count - 1; i >= 0;i--)
            {
                if (list[i].isAvailable == false)
                {
                    list.RemoveAt(i);
                }
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Library> mainList = Library.Retrive();
            Console.WriteLine(mainList.Count);

            Library newBook1 = new Library { bookId = 102, titleName = "C1", authorName = "Danjay", genre = "Coding", isAvailable = true, price = 1010.10 };
            Library newBook2 = new Library { bookId = 102, titleName = "C2", authorName = "Danjay", genre = "Coding", isAvailable = false, price = 1010.10 };
            Library newBook3 = new Library { bookId = 102, titleName = "C3", authorName = "Danjay", genre = "Coding", isAvailable = false, price = 1010.10 };
            Library newBook4 = new Library { bookId = 102, titleName = "C4", authorName = "Danjay", genre = "Coding", isAvailable = true, price = 1010.10 };

            Library.AddBook(newBook1, mainList);
            Library.AddBook(newBook2, mainList);
            Library.AddBook(newBook3, mainList);
            Library.AddBook(newBook4, mainList) ;

            Library foundBook = Library.SearchBook("C", mainList);
            if (foundBook != null)
            {
                Console.WriteLine(foundBook.titleName + " " + foundBook.authorName);
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
                List<Library> foundBooks = Library.SearchAllBook("C", mainList);
            foreach(Library book in foundBooks)
            {
                Console.WriteLine(book.titleName + " " + book.authorName);
            }

            List<Library> foundedBookss = Library.availableBooks(mainList);

            foreach(Library books in foundedBookss)
            {
                Console.WriteLine($"Book {books.titleName}");
            }

            foreach (Library book in mainList)
            {
                Console.WriteLine(book.titleName+ " " + book.isAvailable);
            }

            Library.removeUnavailableBooks(mainList);

            foreach( Library book in mainList)
            {
                Console.WriteLine(book.titleName);
            }

            Console.ReadLine();
        }
    }
}
