using Module25_Zadanie.BusinessLogicLayer.Models;
using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.BookViews
{
    public class AllBookByAuthorAndYearsPeriodView
    {
        private BookService _bookService;

        public AllBookByAuthorAndYearsPeriodView()
        {
            _bookService = new BookService();
            try
            {
                int inputGenre;
                string genre;
                Console.WriteLine("Выберите жанр книги");
                ViewGenre();
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out inputGenre))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Выберите номер жанра из списка");
                    }
                }
                switch (inputGenre)
                {
                    case 1:
                        genre = "Учебная литература";
                        break;
                    case 2:
                        genre = "Наука";
                        break;
                    case 3:
                        genre = "Фантастика";
                        break;
                    case 4:
                        genre = "Сказка";
                        break;
                    case 5:
                        genre = "Роман";
                        break;
                    default:
                        Console.WriteLine("Выбранного жанра нет в списке");
                        return;
                }
                int startYear;
                Console.WriteLine("Введите год старта публикации");
                if (!int.TryParse(Console.ReadLine(), out startYear))
                {
                    Console.WriteLine("Значение недопустимо");
                    return;
                }
                int endYear;
                Console.WriteLine("Введите год окончания публикации");
                if (!int.TryParse(Console.ReadLine(), out endYear))
                {
                    Console.WriteLine("Значение недопустимо");
                    return;
                }
                try
                {
                    List<BookData> bookData = _bookService.GetAllBooksByGenreAndYearsPeriod(genre, startYear, endYear);
                    foreach (BookData bookDataItem in bookData)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Регистрационный номер книги: {bookDataItem.Id}");
                        Console.WriteLine($"Название: {bookDataItem.Name}");
                        Console.WriteLine($"Автор: {bookDataItem.Author}");
                        Console.WriteLine($"Жанр: {bookDataItem.Genre}");
                        Console.WriteLine($"Год издания: {bookDataItem.Year}");
                        Console.WriteLine();
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Книги не найдены");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        private void ViewGenre()
        {
            //набор для теста. Можно расширить
            Console.WriteLine();
            Console.WriteLine("1 - Учебная литература");
            Console.WriteLine("2 - Наука");
            Console.WriteLine("3 - Фантастика");
            Console.WriteLine("4 - Сказка");
            Console.WriteLine("5 - Роман");
        }
    }
}