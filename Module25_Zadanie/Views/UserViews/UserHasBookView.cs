using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.UserViews
{
    public class UserHasBookView
    {
        private UserService _userService;
        public UserHasBookView()
        {
            _userService = new UserService();
            try
            {
                Console.WriteLine("Введите номер билета пользователя.");
                Guid inputUserId = Guid.Parse(Console.ReadLine());
                Console.WriteLine("Введите регистрационный номер книги.");
                Guid inputBookId = Guid.Parse(Console.ReadLine());
                Console.WriteLine();
                if (_userService.UserHasBook(inputUserId, inputBookId))
                {
                    Console.WriteLine("Книга на руках у пользователя.");
                }
                else
                {
                    Console.WriteLine("У пользователя нет данной книги.");
                    Console.WriteLine();
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Пользователь или книга с такими данными не найдены");
            }
            catch (Exception)
            {
                Console.WriteLine("Введите корректный Id");
            }
        }
    }
}