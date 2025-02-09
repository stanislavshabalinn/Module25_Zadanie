using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.UserViews
{
    public class UserByIdView
    {
        private UserService _userService;
        public UserByIdView()
        {
            _userService = new UserService();
            Console.WriteLine("Введите номер билета пользователя");
            try
            {
                Guid inputId = Guid.Parse(Console.ReadLine());
                var userData = _userService.FindUserById(inputId);
                Console.WriteLine();
                Console.WriteLine($"Идентификатор: {userData.Id}");
                Console.WriteLine($"Имя: {userData.Name}");
                Console.WriteLine($"Фамилия: {userData.LastName}");
                Console.WriteLine($"eMail: {userData.eMail}");
                Console.WriteLine();
            }
            catch (ArgumentNullException e)
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