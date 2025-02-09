using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.UserViews
{
    public class UserBookCountView
    {
        private UserService _userService;
        public UserBookCountView()
        {
            _userService = new UserService();
            Console.WriteLine("Введите номер билета пользователя");
            try
            {
                Guid inputId = Guid.Parse(Console.ReadLine());
                var userData = _userService.FindUserById(inputId);
                Console.WriteLine($"Количество книг у пользователя {userData.Name}: {_userService.UserBooksCount(userData)}");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Пользователь с таким билетом не найдены");
            }
            catch (Exception)
            {
                Console.WriteLine("Введите корректный Id");
            }
        }
    }
}