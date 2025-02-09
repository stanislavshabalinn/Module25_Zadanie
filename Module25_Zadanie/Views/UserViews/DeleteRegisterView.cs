using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.UserViews
{
    public class DeleteRegisterView
    {
        private UserService _userService;

        public DeleteRegisterView()
        {
            _userService = new UserService();
            Console.WriteLine("Введите номер билета пользователя");
            try
            {
                Guid inputId = Guid.Parse(Console.ReadLine());
                _userService.DeleteRegister(inputId);
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