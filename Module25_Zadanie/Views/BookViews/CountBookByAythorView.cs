using Module25_Zadanie.BusinessLogicLayer.Models;
using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.BookViews
{
    public class CountBookByAythorView
    {
        private BookService _bookService;

        public CountBookByAythorView()
        {
            _bookService = new BookService();
            Console.WriteLine("Выберите номер автора из списка");
            BookData[] books = _bookService.GetAllBooks().DistinctBy(book => book.Author).ToArray();
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {books[i].Author}");
            }
            int selectAuthor;
            if (!int.TryParse(Console.ReadLine(), out selectAuthor))
            {
                Console.WriteLine("Введено недопустимое значение");
            }
            else
            {
                Console.WriteLine($"Количество книг у выбранного автора: {_bookService.CountBookByAuthor(books[--selectAuthor].Author)}");
            }
        }
    }
}