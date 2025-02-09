﻿using Module25_Zadanie.BusinessLogicLayer.Models;
using Module25_Zadanie.BusinessLogicLayer.Services;

namespace Module25_Zadanie.PresentationLogicLayer.Views.BookViews
{
    public class AllBookSortedDescYearView
    {
        private BookService _bookService;

        public AllBookSortedDescYearView()
        {
            _bookService = new BookService();
            try
            {
                List<BookData> bookData = _bookService.GetAllSortedDescYearBooks();
                foreach (BookData bookDataItem in bookData)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Регистрационный номер книги: {bookDataItem.Id}");
                    Console.WriteLine($"Название: {bookDataItem.Name}");
                    Console.WriteLine($"Автор: {bookDataItem.Author}");
                    Console.WriteLine($"Жанр: {bookDataItem.Genre}");
                    Console.WriteLine($"Год издания: {bookDataItem.Year}");
                    Console.WriteLine();
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Книги не найдены");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}