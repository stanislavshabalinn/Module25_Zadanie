using Module25_Zadanie.BusinessLogicLayer.Models;
using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.UserViews
{
    public class UserAddBookView
    {
        private UserService _userService;
        private BookService _bookService;

        public UserAddBookView()
        {
            _userService = new UserService();
            _bookService = new BookService();
            try
            {
                Console.WriteLine("Введите номер билета пользователя.");
                Guid inputUserId = Guid.Parse(Console.ReadLine());
                Console.WriteLine("Введите регистрационный номер книги.");
                Guid inputBookId = Guid.Parse(Console.ReadLine());
                Console.WriteLine();
                var userData = _userService.FindUserById(inputUserId);
                var bookData = _bookService.FindBookById(inputBookId);
                if (userData == null)
                {
                    throw new ArgumentNullException();
                }
                if (bookData == null)
                {
                    throw new ArgumentNullException();
                }
                _userService.UserAddBook(userData, bookData);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Пользователь или книга с такими данными не найдены");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}