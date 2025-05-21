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

        public static ResponseBookJson EditBook(RequestBookJson book, int id)
        {
            var existingBook = Livros.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                throw new Exception("Livro não encontrado.");
            }
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.Price = book.Price;
            existingBook.Stock = book.Stock;
            var response = new ResponseBookJson
            {
                Id = existingBook.Id,
                Title = existingBook.Title,
            };
            return response;
        }
    }
}
