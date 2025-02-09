using Module25_Zadani.BusinessLogicLayer.Models;
using Module25_Zadani.BusinessLogicLayer.Services;

namespace Module25_Zadani.PresentationLogicLayer.Views.UserViews
{
    public class RegisterView
    {
        private UserService _userService;
        public RegisterView()
        {
            _userService = new UserService();
            string inputName;
            string inputLastName;
            string inputEmail;
            Console.WriteLine("Введите имя нового пользователя");
            inputName = Console.ReadLine();
            Console.WriteLine("Введите фамилию нового пользователя");
            inputLastName = Console.ReadLine();
            Console.WriteLine("Введите eMail нового пользователя");
            inputEmail = Console.ReadLine();
            var userRegistrationData = new UserRegistrationData()
            {
                Name = inputName,
                LastName = inputLastName,
                eMail = inputEmail
            };
            _userService.Register(userRegistrationData);
        }
    }
}