using Module25_Zadanie.PresentationLogicLayer.Views.BookViews;
using Module25_Zadanie.PresentationLogicLayer.Views.UserViews;


namespace Module25_Zadanie.PresentationLogicLayer
{
    public class UserInterface
    {
        public void Start()
        {
            while (true)
            {
                Hello();
                int inputNumber;
                bool result = int.TryParse(Console.ReadLine(), out inputNumber);
                if (result)
                {
                    switch (inputNumber)
                    {
                        case 1:
                            _ = new RegisterView();
                            break;
                        case 2:
                            _ = new UserView();
                            break;
                        case 3:
                            _ = new UserByIdView();
                            break;
                        case 4:
                            _ = new UpdateUserNameView();
                            break;
                        case 5:
                            _ = new UserHasBookView();
                            break;
                        case 6:
                            _ = new UserBookCountView();
                            break;
                        case 7:
                            _ = new UserAddBookView();
                            break;
                        case 8:
                            _ = new UserReturnBook();
                            break;
                        case 9:
                            _ = new DeleteRegisterView();
                            break;
                        case 10:
                            _ = new BookByIdView();
                            break;
                        case 11:
                            _ = new AllBookView();
                            break;
                        case 12:
                            _ = new RegisterBookView();
                            break;
                        case 13:
                            _ = new UpdatePublishYearBookView();
                            break;
                        case 14:
                            _ = new DeleteRegisterBookView();
                            break;
                        case 15:
                            _ = new CountBookByGenreView();
                            break;
                        case 16:
                            _ = new CountBookByAythorView();
                            break;
                        case 17:
                            _ = new BookByAuthorAndNameView();
                            break;
                        case 18:
                            _ = new LatestBookView();
                            break;
                        case 19:
                            _ = new AllBookSortedView();
                            break;
                        case 20:
                            _ = new AllBookSortedDescYearView();
                            break;
                        case 21:
                            _ = new AllBookByAuthorAndYearsPeriodView();
                            break;
                        default:
                            Console.WriteLine("Выбранное действие отсутствует в списке.");
                            Console.WriteLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Выберите номер из списка.");
                    Console.WriteLine();
                }
            }
        }

        public void Hello()
        {
            Console.WriteLine("Добро пожаловать в библиотеку. Выберите действие:");
            Console.WriteLine();
            Console.WriteLine("1 - зарегистрировать нового пользователя");
            Console.WriteLine("2 - просмотреть всех пользователей");
            Console.WriteLine("3 - найти пользователя по номеру билета");
            Console.WriteLine("4 - обновить имя пользователя");
            Console.WriteLine("5 - проверить есть ли книга на руках у пользователя");
            Console.WriteLine("6 - просмотреть количество книг у пльзователя");
            Console.WriteLine("7 - добавить книгу пользователю");
            Console.WriteLine("8 - возврат книги");
            Console.WriteLine("9 - удалить пользователя");
            Console.WriteLine();
            Console.WriteLine("10 - найти книгу по регистрационному номеру");
            Console.WriteLine("11 - вывести список всех книг");
            Console.WriteLine("12 - зарегистрировать книгу");
            Console.WriteLine("13 - обновить год выпуска книги");
            Console.WriteLine("14 - удалить кннигу из библиотеки");
            Console.WriteLine("15 - посчитать количество книг по жанру");
            Console.WriteLine("16 - просмотреть количество книг у автора");
            Console.WriteLine("17 - проверить есть ли книга определенного автора и с определенным названием в библиотеке.");
            Console.WriteLine("18 - получить последнюю печатную книгу");
            Console.WriteLine("19 - Получение списка всех книг, отсортированного в алфавитном порядке по названию.");
            Console.WriteLine("20 - Получение списка всех книг, отсортированного в порядке убывания года их выхода.");
            Console.WriteLine("21 - Получить список книг определенного жанра и вышедших между определенными годами.");
            Console.WriteLine();
        }
    }
}