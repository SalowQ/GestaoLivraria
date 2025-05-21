using GestaoLivraria.Communication.Requests;
using GestaoLivraria.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoLivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status201Created)]
        public IActionResult AddBook([FromBody] RequestBookJson book)
        {
            if (book == null || string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.Genre) || BookGenre.IsInvalid(book.Genre) || book.Price <= 0 || book.Stock <= 0)
            {
                return BadRequest("Erro na criação do livro.");
            }
            var response = FakeBookDatabase.AddBook(book);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetBooks()
        {
            if (!FakeBookDatabase.Books.Any())
            {
                return NoContent();
            }

            return Ok(FakeBookDatabase.Books);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status200OK)]
        public IActionResult EditBook([FromBody] RequestBookJson book, [FromRoute] int id)
        {
            if (book == null || string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.Genre) || book.Price <= 0 || book.Stock <= 0)
            {
                return BadRequest("Erro na edição do livro.");
            }
            var response = FakeBookDatabase.EditBook(book, id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = FakeBookDatabase.Books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound("Livro não encontrado.");
            }
            FakeBookDatabase.Books.Remove(existingBook);
            return NoContent();
        }
    }
}
