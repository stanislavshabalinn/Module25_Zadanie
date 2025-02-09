using Module25_Zadanie.BusinessLogicLayer.Models;
using Module25_Zadanie.BusinessLogicLayer.Services;


namespace Module25_Zadanie.PresentationLogicLayer
{
    
    
        public class Program
        {
            private static UserService _userService;
            private static BookService _bookService;

            //инициализация БД стартовыми данными для теста
            static Program()
            {
                _userService = new UserService();
                _bookService = new BookService();

                var user1Data = new UserRegistrationData()
                {
                    Name = "Иван",
                    LastName = "Иванов",
                    eMail = "Ivan@mail.ru"
                };
                var user2Data = new UserRegistrationData()
                {
                    Name = "Пётр",
                    LastName = "Петров",
                    eMail = "Petr@mail.ru"
                };
                var user3Data = new UserRegistrationData()
                {
                    Name = "Фёдор",
                    LastName = "Фёдоров",
                    eMail = "Fedor@mail.ru"
                };

                var user4Data = new UserRegistrationData()
                {
                    Name = "Андрей",
                    LastName = "Андреев",
                    eMail = "Andrey@mail.ru"
                };
                var user5Data = new UserRegistrationData()
                {
                    Name = "Виктор",
                    LastName = "Викторов",
                    eMail = "Viktor@mail.ru"
                };

                try
                {
                    _userService.Register(user1Data);
                    _userService.Register(user2Data);
                    _userService.Register(user3Data);
                    _userService.Register(user4Data);
                    _userService.Register(user5Data);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Попытка добавить пользователя неуспешна. Некорректное значение");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }

                var book1Data = new BookRegistrationData()
                {
                    Name = "C# 10 и .NET 6. Современная кроссплатформенная разработка",
                    Author = "Марк Прайс",
                    Genre = "Учебная литература",
                    Year = 2023
                };
                var book2Data = new BookRegistrationData()
                {
                    Name = "Программируем на C# 8.0",
                    Author = "Иэн Гриффитс",
                    Genre = "Учебная литература",
                    Year = 2021
                };
                var book3Data = new BookRegistrationData()
                {
                    Name = "Паттерны проектирования для C# и платформы .NET Core",
                    Author = "Арораа Г.",
                    Genre = "Учебная литература",
                    Year = 2021
                };
                var book4Data = new BookRegistrationData()
                {
                    Name = "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#. 4-е изд.",
                    Author = "Рихтер Д.",
                    Genre = "Учебная литература",
                    Year = 2022
                };
                var book5Data = new BookRegistrationData()
                {
                    Name = "Изучаем C# через разработку игр на Unity",
                    Author = "Харрисон Фероне",
                    Genre = "Учебная литература",
                    Year = 2022
                };
                var book6Data = new BookRegistrationData()
                {
                    Name = "Золотой ключик или приключения Буратино",
                    Author = "Толстой А.",
                    Genre = "Сказка",
                    Year = 1999
                };
                var book7Data = new BookRegistrationData()
                {
                    Name = "Мартин Иден",
                    Author = "Лондон Д.",
                    Genre = "Роман",
                    Year = 1992
                };

                try
                {
                    _bookService.Register(book1Data);
                    _bookService.Register(book2Data);
                    _bookService.Register(book3Data);
                    _bookService.Register(book4Data);
                    _bookService.Register(book5Data);
                    _bookService.Register(book6Data);
                    _bookService.Register(book7Data);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Попытка добавить книгу неуспешна. Некорректное значение");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }

            public static void Main(string[] args)
            {
                new UserInterface().Start();
            }
        }
    }