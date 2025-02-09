using Module25_Zadanie.BusinessLogicLayer.Services;
using Module25_Zadanie.BusinessLogicLayer.Models;

namespace Module25_Zadanie.PresentationLogicLayer.Views.BookViews
{
    public class CountBookByGenreView
    {
        private BookService _bookService;

        public CountBookByGenreView()
        {
            _bookService = new BookService();
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
            Console.WriteLine($"Количество книг в этой категории: {_bookService.CountBookByGenre(genre)}");
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