using Module25_Zadanie.Entity;

namespace Module25_Zadanie.DataAccessLayer.Repositories
{
    public interface IBookRepository
    {
        //Задание 25.3.5*
        public Book FindById(Guid Id);

        public List<Book> FindAllBooks();

        public void Create(Book book);

        public void Delete(Book book);

        public void UpdateBookYear(Guid Id, int year);

        //Задание 25.5.4*
        //Получать список книг определенного жанра и вышедших между определенными годами.
        public List<Book> FindBooksByGenreAndYear(string genre, int startYear, int endYear);

        //Получать количество книг определенного автора в библиотеке.
        public int CountBooksByAuthor(string author);

        //Получать количество книг определенного жанра в библиотеке.
        public int CountBooksByGenre(string genre);

        //Получать булевый флаг о том,
        //есть ли книга определенного автора и с определенным названием в библиотеке.
        public bool Exist(string author, string name);

        //Получение последней вышедшей книги.
        public Book FindBookByLatestYear();

        //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<Book> FindAllBooksOrderByName();

        //Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public List<Book> FindAllBooksOrderByYearDesc();
    }
}