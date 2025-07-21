using Microsoft.AspNetCore.Mvc;
using BibliotecaApi.Models;
using BibliotecaApi.Repositories.Interfaces;

namespace BibliotecaApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book) =>
            Ok(await _repository.AddAsync(book));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (id != book.BookId) return BadRequest();
            return Ok(await _repository.UpdateAsync(book));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repository.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }
    }
}