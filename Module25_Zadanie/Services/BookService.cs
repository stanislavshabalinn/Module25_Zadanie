using Module25_Zadanie.BusinessLogicLayer.Models;
using Module25_Zadanie.DataAccessLayer.Entity;
using Module25_Zadanie.DataAccessLayer.Repositories;

namespace Module25_Zadanie.BusinessLogicLayer.Services
{
    public class BookService
    {
        private IBookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public void Register(BookRegistrationData bookRegistrationData)
        {
            if (string.IsNullOrEmpty(bookRegistrationData.Name) ||
                string.IsNullOrEmpty(bookRegistrationData.Author) ||
                string.IsNullOrEmpty(bookRegistrationData.Genre))
            {
                throw new ArgumentNullException();
            }
            //проверяем чтобы в библиотеку не попали слишком старые книги или книги с непрвильным годом выпуска
            if (bookRegistrationData.Year < 1980 || bookRegistrationData.Year > DateTime.Now.Year)
            {
                throw new InvalidDataException();
            }
            var book = new Book()
            {
                Name = bookRegistrationData.Name,
                Author = bookRegistrationData.Author,
                Genre = bookRegistrationData.Genre,
                Year = bookRegistrationData.Year
            };
            _bookRepository.Create(book);
        }

        public void UpdateBookYear(Guid Id, int year)
        {
            var book = _bookRepository.FindById(Id);
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            _bookRepository.UpdateBookYear(Id, year);
        }

        public BookData GetLatestBook()
        {
            var book = _bookRepository.FindBookByLatestYear();
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            var bookData = new BookData()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Genre = book.Genre,
                Year = book.Year
            };
            return bookData;
        }

        public List<BookData> GetAllSortedBooks()
        {
            List<Book> books = _bookRepository.FindAllBooksOrderByName();
            List<BookData> bookData = new List<BookData>();
            if (books != null && books.Count > 0)
            {
                foreach (var book in books)
                {
                    bookData.Add(new BookData()
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Author = book.Author,
                        Genre = book.Genre,
                        Year = book.Year
                    });
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
            return bookData;
        }

        public List<BookData> GetAllSortedDescYearBooks()
        {
            List<Book> books = _bookRepository.FindAllBooksOrderByYearDesc();
            List<BookData> bookData = new List<BookData>();
            if (books != null && books.Count > 0)
            {
                foreach (var book in books)
                {
                    bookData.Add(new BookData()
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Author = book.Author,
                        Genre = book.Genre,
                        Year = book.Year
                    });
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
            return bookData;
        }

        public List<BookData> GetAllBooksByGenreAndYearsPeriod(string genre, int startYear, int endYear)
        {
            List<Book> books = _bookRepository.FindBooksByGenreAndYear(genre, startYear, endYear);
            List<BookData> bookData = new List<BookData>();
            if (books != null && books.Count > 0)
            {
                foreach (var book in books)
                {
                    bookData.Add(new BookData()
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Author = book.Author,
                        Genre = book.Genre,
                        Year = book.Year
                    });
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
            return bookData;
        }

        public void DeleteBook(Guid Id)
        {
            var book = _bookRepository.FindById(Id);
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            _bookRepository.Delete(book);
        }

        public int CountBookByGenre(string genre)
        {
            return _bookRepository.CountBooksByGenre(genre);
        }

        public int CountBookByAuthor(string author)
        {
            int count = _bookRepository.CountBooksByAuthor(author);
            return count;
        }

        public bool Exists(string author, string name)
        {
            if (author == null)
            {
                throw new ArgumentNullException();
            }
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            bool result = _bookRepository.Exist(author, name);
            return result;
        }

        public BookData FindBookById(Guid Id)
        {
            var book = _bookRepository.FindById(Id);
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var bookData = new BookData()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Genre = book.Genre,
                    Year = book.Year
                };
                return bookData;
            }
        }
        public List<BookData> GetAllBooks()
        {
            List<Book> books = _bookRepository.FindAllBooks();
            List<BookData> bookData = new List<BookData>();
            if (books != null && books.Count > 0)
            {
                foreach (var book in books)
                {
                    bookData.Add(new BookData()
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Author = book.Author,
                        Genre = book.Genre,
                        Year = book.Year
                    });
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
            return bookData;
        }
    }
}