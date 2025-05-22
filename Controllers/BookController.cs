using GestaoLivraria.Communication.Requests;
using GestaoLivraria.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoLivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// Adiciona um livro novo.
        /// </summary>
        /// <remarks>
        /// Gêneros (genre) aceitos::
        ///
        ///     
        ///     {
        ///         "Ficção",
        ///         "Ciência",
        ///         "História",
        ///         "Fantasia",
        ///         "Mistério",
        ///         "Romance"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna o ID e o título do livro criado.</response>
        /// <response code="400">Retorna erro caso qualquer propriedade seja inválida ou esteja vazia.</response>
        [HttpPost]
        [Produces("application/json")]
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

        /// <summary>
        /// Retorna todos os livros.
        /// </summary>
        ///<response code="200">Retorna a lista de livros disponíveis.</response>
        ///<response code="204">Não retorna nenhum conteúdo pois não há livros disponíveis.</response>
        [HttpGet]
        [Produces("application/json")]
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

        /// <summary>
        /// Atualiza um livro existente.
        /// </summary>
        /// <response code="200">Retorna o ID e o título do livro editado.</response>
        /// <response code="400">Retorna erro caso qualquer propriedade seja inválida ou esteja vazia.</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
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

        /// <summary>
        /// Deleta um livro existente.
        /// </summary>
        ///<response code="204">Não retorna nenhum conteúdo pois o livro foi deletado.</response>
        ///<response code="400">Retorna erro caso o livro não for encontrado a partir do ID.</response>
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
