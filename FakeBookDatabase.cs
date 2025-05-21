using GestaoLivraria.Communication.Requests;
using GestaoLivraria.Communication.Responses;

namespace GestaoLivraria
{
    public class FakeBookDatabase
    {
        private static int _nextId = 1;
        public static List<Book> Livros { get; } = new();

        public static ResponseBookJson AddBook(RequestBookJson book)
        {
            var newBook = new Book
            {
                Id = _nextId++,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Price = book.Price,
                Stock = book.Stock
            };
            Livros.Add(newBook);
            var response = new ResponseBookJson
            {
                Id = newBook.Id,
                Title = newBook.Title,
            };
            return response;
        }
    }
}
