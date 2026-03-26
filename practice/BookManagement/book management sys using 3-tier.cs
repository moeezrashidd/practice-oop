using System;
using System.Collections.Generic;

public class Class1
{
    class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }
        public string BorrowerName { get; set; }

        public Book(int bookID, string title, string author, string isbn, string genre, bool isAvailable, string borrowerName)
        {
            BookID = bookID;
            Title = title;
            Author = author;
            ISBN = isbn;
            Genre = genre;
            IsAvailable = isAvailable;
            BorrowerName = borrowerName;
        }
    }

    class BookDAL
    {
        private List<Book> books = new List<Book>();

        public bool AddBook(Book book)
        {
            books.Add(book);
            return true;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookByISBN(string isbn)
        {
            foreach (Book item in books)
            {
                if (item.ISBN == isbn)
                {
                    return item;
                }
            }
            return null;
        }

        public Book GetBookById(int bookID)
        {
            foreach (Book item in books)
            {
                if (item.BookID == bookID)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> authorBooks = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Author.ToLower() == author.ToLower())
                {
                    authorBooks.Add(book);
                }
            }
            return authorBooks;
        }

        public bool UpdateBook(Book updatedBook)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].BookID == updatedBook.BookID)
                {
                    books[i] = updatedBook;
                    return true;
                }
            }
            return false;
        }

        public bool DeleteBook(int id)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].BookID == id)
                {
                    books.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public List<Book> GetBorrowedBooks()
        {
            List<Book> borrowedBooks = new List<Book>();

            foreach (Book book in books)
            {
                if (!book.IsAvailable)
                {
                    borrowedBooks.Add(book);
                }
            }
            return borrowedBooks;
        }
    }

    class BookBLL
    {
        private BookDAL dal = new BookDAL();

        public bool AddBook(int id, string title, string author, string isbn, string genre, string borrowerName, bool isAvailable = true)
        {
            // Validations
            if (id <= 0)
            {
                Console.WriteLine("Error: ID must be greater than 0");
                return false;
            }

            if (string.IsNullOrEmpty(title) || title.Length < 3)
            {
                Console.WriteLine("Error: Title must be at least 3 characters");
                return false;
            }

            if (string.IsNullOrEmpty(author) || author.Length < 3)
            {
                Console.WriteLine("Error: Author must be at least 3 characters");
                return false;
            }

            if (string.IsNullOrEmpty(isbn))
            {
                Console.WriteLine("Error: ISBN cannot be empty");
                return false;
            }

            // ISBN format validation
            if (!System.Text.RegularExpressions.Regex.IsMatch(isbn, @"^\d{3}-\d{3}-\d{3}$"))
            {
                Console.WriteLine("Error: ISBN must be in format XXX-XXX-XXX");
                return false;
            }

            // Check for duplicate ISBN
            Book existingBook = dal.GetBookByISBN(isbn);
            if (existingBook != null)
            {
                Console.WriteLine("Error: Book with this ISBN already exists");
                return false;
            }

            // Genre validation
            string[] validGenres = { "Fiction", "Science", "History", "Technology", "Other" };
            bool isValidGenre = false;
            foreach (string validGenre in validGenres)
            {
                if (genre == validGenre)
                {
                    isValidGenre = true;
                    break;
                }
            }
            if (!isValidGenre)
            {
                Console.WriteLine("Error: Invalid genre. Choose from: Fiction, Science, History, Technology, Other");
                return false;
            }

            Book newBook = new Book(id, title, author, isbn, genre, isAvailable, borrowerName);
            return dal.AddBook(newBook);
        }

        public void DisplayAllBooks()
        {
            List<Book> books = dal.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No books found in the library");
                return;
            }

            Console.WriteLine("\n=== All Books ===");
            foreach (Book book in books)
            {
                string status = book.IsAvailable ? "Available" : $"Borrowed by {book.BorrowerName}";
                Console.WriteLine($"ID: {book.BookID} | Title: {book.Title} | Author: {book.Author} | ISBN: {book.ISBN} | Genre: {book.Genre} | Status: {status}");
            }
        }

        public void BorrowBook(string borrowerName, string isbn)
        {
            if (string.IsNullOrEmpty(borrowerName) || borrowerName.Length < 3)
            {
                Console.WriteLine("Error: Borrower name must be at least 3 characters");
                return;
            }

            Book book = dal.GetBookByISBN(isbn);

            if (book == null)
            {
                Console.WriteLine("Error: Book with the given ISBN not found");
                return;
            }

            if (book.IsAvailable)
            {
                book.IsAvailable = false;
                book.BorrowerName = borrowerName;
                dal.UpdateBook(book);
                Console.WriteLine($"Success: '{book.Title}' borrowed by {borrowerName}");
            }
            else
            {
                Console.WriteLine($"Error: '{book.Title}' is already borrowed by {book.BorrowerName}");
            }
        }

        public void ReturnBook(string isbn)
        {
            Book book = dal.GetBookByISBN(isbn);

            if (book == null)
            {
                Console.WriteLine("Error: Book with the given ISBN not found");
                return;
            }

            if (!book.IsAvailable)
            {
                book.IsAvailable = true;
                book.BorrowerName = null;
                dal.UpdateBook(book);
                Console.WriteLine($"Success: '{book.Title}' has been returned");
            }
            else
            {
                Console.WriteLine($"Error: '{book.Title}' is already available in the library");
            }
        }

        public void SearchByAuthor(string author)
        {
            if (string.IsNullOrEmpty(author))
            {
                Console.WriteLine("Error: Author name cannot be empty");
                return;
            }

            List<Book> authorBooks = dal.GetBooksByAuthor(author);

            if (authorBooks.Count == 0)
            {
                Console.WriteLine($"No books found by author: {author}");
                return;
            }

            Console.WriteLine($"\n=== Books by {author} ===");
            foreach (Book book in authorBooks)
            {
                string status = book.IsAvailable ? "Available" : $"Borrowed by {book.BorrowerName}";
                Console.WriteLine($"ID: {book.BookID} | Title: {book.Title} | ISBN: {book.ISBN} | Genre: {book.Genre} | Status: {status}");
            }
        }

        public void DisplayBorrowedBooks()
        {
            List<Book> borrowedBooks = dal.GetBorrowedBooks();

            if (borrowedBooks.Count == 0)
            {
                Console.WriteLine("No books are currently borrowed");
                return;
            }

            Console.WriteLine("\n=== Borrowed Books ===");
            foreach (Book book in borrowedBooks)
            {
                Console.WriteLine($"ID: {book.BookID} | Title: {book.Title} | Author: {book.Author} | Borrowed by: {book.BorrowerName}");
            }
        }

        public bool DeleteBook(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Error: Invalid ID");
                return false;
            }

            Book book = dal.GetBookById(id);

            if (book == null)
            {
                Console.WriteLine($"Error: Book with ID {id} not found");
                return false;
            }

            if (!book.IsAvailable)
            {
                Console.WriteLine($"Error: Cannot delete '{book.Title}' because it is currently borrowed by {book.BorrowerName}");
                return false;
            }

            bool deleted = dal.DeleteBook(id);
            if (deleted)
            {
                Console.WriteLine($"Success: '{book.Title}' has been deleted");
            }
            return deleted;
        }
    }

    class BookUI
    {
        static void Main(string[] args)
        {
            BookBLL bll = new BookBLL();
            int nextId = 1;

            while (true)
            {
                Console.WriteLine("\n=== Library Management System ===");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Borrow a Book");
                Console.WriteLine("4. Return a Book");
                Console.WriteLine("5. Search Books by Author");
                Console.WriteLine("6. View Borrowed Books Only");
                Console.WriteLine("7. Delete Book");
                Console.WriteLine("8. Exit");
                Console.Write("\nSelect option: ");

                string input = Console.ReadLine();
                int opt;

                if (!int.TryParse(input, out opt))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (opt)
                {
                    case 1:
                        Console.WriteLine("\n--- Add New Book ---");

                        Console.Write("Enter Book Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter Author Name: ");
                        string author = Console.ReadLine();

                        Console.Write("Enter ISBN (XXX-XXX-XXX): ");
                        string isbn = Console.ReadLine();

                        Console.Write("Enter Genre (Fiction/Science/History/Technology/Other): ");
                        string genre = Console.ReadLine();

                        if (bll.AddBook(nextId, title, author, isbn, genre, null))
                        {
                            Console.WriteLine($"Book added successfully with ID: {nextId}");
                            nextId++;
                        }
                        break;

                    case 2:
                        bll.DisplayAllBooks();
                        break;

                    case 3:
                        Console.WriteLine("\n--- Borrow a Book ---");

                        Console.Write("Enter ISBN of book to borrow: ");
                        string borrowIsbn = Console.ReadLine();

                        Console.Write("Enter Borrower Name: ");
                        string borrowerName = Console.ReadLine();

                        bll.BorrowBook(borrowerName, borrowIsbn);
                        break;

                    case 4:
                        Console.WriteLine("\n--- Return a Book ---");

                        Console.Write("Enter ISBN of book to return: ");
                        string returnIsbn = Console.ReadLine();

                        bll.ReturnBook(returnIsbn);
                        break;

                    case 5:
                        Console.WriteLine("\n--- Search by Author ---");

                        Console.Write("Enter Author Name: ");
                        string searchAuthor = Console.ReadLine();

                        bll.SearchByAuthor(searchAuthor);
                        break;

                    case 6:
                        bll.DisplayBorrowedBooks();
                        break;

                    case 7:
                        Console.WriteLine("\n--- Delete Book ---");

                        Console.Write("Enter Book ID to delete: ");
                        int deleteId;
                        if (int.TryParse(Console.ReadLine(), out deleteId))
                        {
                            bll.DeleteBook(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID");
                        }
                        break;

                    case 8:
                        Console.WriteLine("\nThank you for using our Library Management System!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please select 1-8");
                        break;
                }
            }
        }
    }
}