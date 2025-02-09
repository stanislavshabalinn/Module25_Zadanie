using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.BookViews
{
    public class UpdatePublishYearBookView
    {
        private BookService _bookService;

        public UpdatePublishYearBookView()
        {
            _bookService = new BookService();
            try
            {
                Console.WriteLine("Введите регистрационный номер книги");
                Guid inputId = Guid.Parse(Console.ReadLine());
                Console.WriteLine("Введите год публикации книги");
                int year;
                if (!int.TryParse(Console.ReadLine(), out year))
                {
                    Console.WriteLine("Значение недопустимо");
                    return;
                }
                _bookService.UpdateBookYear(inputId, year);
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