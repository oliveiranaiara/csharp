using BibliotecaApi.Models.Interfaces;
using BibliotecaApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _repo;

        public AuthorsController(IAuthorRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await _repo.GetByIdAsync(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Author author)
        {
            var created = await _repo.AddAsync(author);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Author author)
        {
            if (id != author.Id) return BadRequest();
            await _repo.UpdateAsync(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
