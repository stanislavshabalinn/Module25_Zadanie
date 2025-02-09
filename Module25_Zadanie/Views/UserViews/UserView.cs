using Module25_Zadanie.BusinessLogicLayer.Models;
using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.UserViews
{
    internal class UserView
    {
        private UserService _userService;
        public UserView()
        {
            _userService = new UserService();
            try
            {
                List<UserData> userData = _userService.GetAllUsers();
                foreach (UserData userDataItem in userData)
                {
                    Console.WriteLine($"Номер читательского билета: {userDataItem.Id}");
                    Console.WriteLine($"Имя: {userDataItem.Name}");
                    Console.WriteLine($"Фамилия: {userDataItem.LastName}");
                    Console.WriteLine($"eMail: {userDataItem.eMail}");
                    Console.WriteLine();
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Пользователи не найдены");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}