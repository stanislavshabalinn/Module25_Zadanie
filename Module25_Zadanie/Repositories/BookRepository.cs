using Module25_Zadanie.DataAccessLayer.Entity;

namespace Module25_Zadanie.DataAccessLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        //Задание 25.3.5*
        public void Create(Book book)
        {
            using (var dataBase = new DB.AppContext())
            {
                dataBase.Books.Add(book);
                dataBase.SaveChanges();
            }
        }

        public void Delete(Book book)
        {
            using (var dataBase = new DB.AppContext())
            {
                dataBase.Books.Remove(book);
                dataBase.SaveChanges();
            }
        }

        public List<Book> FindAllBooks()
        {
            using (var dataBase = new DB.AppContext())
            {
                var books = dataBase.Books.ToList();
                return books;
            }
        }

        public Book FindById(Guid Id)
        {
            using (var dataBase = new DB.AppContext())
            {
                var book = dataBase.Books.Where(book => book.Id == Id).FirstOrDefault();
                return book;
            }
        }

        public void UpdateBookYear(Guid Id, int year)
        {
            using (var dataBase = new DB.AppContext())
            {
                var book = dataBase.Books.Where(book => book.Id == Id).FirstOrDefault();
                if (book != null)
                {
                    book.Year = year;
                    dataBase.SaveChanges();
                }
            }
        }

        //Задание 25.5.4*
        //Получать список книг определенного жанра и вышедших между определенными годами.
        public List<Book> FindBooksByGenreAndYear(string genre, int startYear, int endYear)
        {
            using (var dataBase = new DB.AppContext())
            {
                var books = dataBase.Books.Where(book =>
                book.Genre == genre &&
                book.Year >= startYear && book.Year <= endYear).ToList();
                return books;
            }
        }

        //Получать количество книг определенного автора в библиотеке.
        public int CountBooksByAuthor(string author)
        {
            using (var dataBase = new DB.AppContext())
            {
                int count = dataBase.Books.Where(book => book.Author == author).Count();
                return count;
            }
        }

        //Получать количество книг определенного жанра в библиотеке.
        public int CountBooksByGenre(string genre)
        {
            using (var dataBase = new DB.AppContext())
            {
                int count = dataBase.Books.Where(book => book.Genre == genre).Count();
                return count;
            }
        }

        //Получать булевый флаг о том,
        //есть ли книга определенного автора и с определенным названием в библиотеке.
        public bool Exist(string author, string name)
        {
            using (var dataBase = new DB.AppContext())
            {
                bool result = false;
                result = dataBase.Books.Where(book =>
                book.Author == author && book.Name == name).Any();
                return result;
            }
        }

        //Получение последней вышедшей книги.
        public Book FindBookByLatestYear()
        {
            using (var dataBase = new DB.AppContext())
            {
                var book = dataBase.Books.OrderByDescending(Book => Book.Year).FirstOrDefault();
                return book;
            }
        }

        //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<Book> FindAllBooksOrderByName()
        {
            using (var dataBase = new DB.AppContext())
            {
                var books = dataBase.Books.OrderBy(book => book.Name).ToList();
                return books;
            }
        }

        //Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public List<Book> FindAllBooksOrderByYearDesc()
        {
            using (var dataBase = new DB.AppContext())
            {
                var books = dataBase.Books.OrderByDescending(book => book.Year).ToList();
                return books;
            }
        }
    }
}