using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{

    namespace LibraryApi.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class BooksController : ControllerBase
        {
            private readonly IBookRepository _bookRepository;

            public BooksController(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            // GET: api/books
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var books = await _bookRepository.GetAllAsync();
                return Ok(books);
            }

            // GET: api/books/{id}
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var book = await _bookRepository.GetByIdAsync(id);
                if (book == null)
                    return NotFound();
                return Ok(book);
            }

            // POST: api/books
            [HttpPost]
            public async Task<IActionResult> Create(Book book)
            {
                var createdBook = await _bookRepository.AddAsync(book);
                return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
            }

            // PUT: api/books/{id}
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, Book book)
            {
                if (id != book.Id)
                    return BadRequest("ID da URL não bate com o ID do corpo da requisição.");

                await _bookRepository.UpdateAsync(book);
                return NoContent();
            }

            // DELETE: api/books/{id}
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _bookRepository.DeleteAsync(id);
                return NoContent();
            }
        }
    }
}

