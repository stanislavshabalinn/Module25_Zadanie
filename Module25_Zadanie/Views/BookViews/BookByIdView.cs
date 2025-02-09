using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.BookViews
{
    public class BookByIdView
    {
        private BookService _bookService;
        public BookByIdView()
        {
            _bookService = new BookService();
            Console.WriteLine("Введите регистрационный номер книги");
            try
            {
                Guid inputId = Guid.Parse(Console.ReadLine());
                var bookData = _bookService.FindBookById(inputId);
                Console.WriteLine();
                Console.WriteLine($"Идентификатор: {bookData.Id}");
                Console.WriteLine($"Название: {bookData.Name}");
                Console.WriteLine($"Автор: {bookData.Author}");
                Console.WriteLine($"Жанр: {bookData.Genre}");
                Console.WriteLine($"Год издания: {bookData.Year}");
                Console.WriteLine();
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