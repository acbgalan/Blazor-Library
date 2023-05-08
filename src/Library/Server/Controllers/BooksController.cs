using Library.Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Library.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id:int}", Name = "GetBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookRepository.GetAsync(id);

            if (book == null)
            {
                return NotFound("Libro no encontrado");
            }

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            if (await _bookRepository.ExitsAsync(book.Title))
            {
                return BadRequest("Ya existe un libro con ese título");
            }

            await _bookRepository.AddAsync(book);
            int saveResult = await _bookRepository.SaveAsync();

            c

            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateBook(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            bool exits = await _bookRepository.ExitsAsync(book.Id);

            if (!exits)
            {
                return NotFound("Libro no encontrado");
            }

            await _bookRepository.UpdateAsync(book);
            int saveResult = await _bookRepository.SaveAsync();

            if (!(saveResult > 0))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Valor no esperado al actualizar libro");
            }

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBook(int id)
        {
            bool exits = await _bookRepository.ExitsAsync(book.Id);

            if (!exits)
            {
                return NotFound("Libro no encontrado");
            }

            await _bookRepository.DeleteAsync(id);
            int saveResult = await _bookRepository.SaveAsync();

            if (!(saveResult > 0))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Valor no esperado al borrar libro");
            }

            return NoContent();
        }


    }
}
