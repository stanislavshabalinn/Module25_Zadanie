using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.BookViews
{
    public class DeleteRegisterBookView
    {
        private BookService _bookService;

        public DeleteRegisterBookView()
        {
            _bookService = new BookService();
            try
            {
                Console.WriteLine("Введите регистрационный номер книги");
                Guid inputId = Guid.Parse(Console.ReadLine());
                _bookService.DeleteBook(inputId);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Книга с таким регистрационным номером не найдена");
            }
            catch (Exception)
            {
                Console.WriteLine("Введите корректный Id");
            }
        }
    }
}