using Module25_Zadanie.BusinessLogicLayer.Models;
using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.BookViews
{
    public class RegisterBookView
    {
        private BookService _bookService;
        public RegisterBookView()
        {
            _bookService = new BookService();
            string inputName;
            string inputAuthor;
            int inputGenre;
            string genre;
            int inputYear;
            Console.WriteLine("Введите название книги");
            inputName = Console.ReadLine();
            Console.WriteLine("Введите фамилию и имя автора");
            inputAuthor = Console.ReadLine();
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
            Console.WriteLine("Введите год издания книги");
            if (!int.TryParse(Console.ReadLine(), out inputYear))
            {
                Console.WriteLine("Значение недопустимо");
                return;
            }
            var bookRegistrationData = new BookRegistrationData()
            {
                Name = inputName,
                Author = inputAuthor,
                Genre = genre,
                Year = inputYear
            };
            _bookService.Register(bookRegistrationData);
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