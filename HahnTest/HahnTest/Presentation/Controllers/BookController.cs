using HahnTest.Domain.Services;
using HahnTest.Presentation.DTOs;
using HahnTest.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HahnTest.Presentation.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : Controller
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAllAsync()
        {
            var books = await _service.GetAllAsync();
            return Ok(books.ToDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetByIdAsync(int id)
        {
            var book = await _service.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book.ToDto());
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] BookDto bookDto)
        {
            var book = bookDto.ToEntity();
            await _service.AddAsync(book);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = book.Id }, book.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] BookDto bookDto)
        {
            if (id != bookDto.Id)
            {
                return BadRequest();
            }

            var existingBook = await _service.GetByIdAsync(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            var book = bookDto.ToEntity();
            await _service.UpdateAsync(book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var existingBook = await _service.GetByIdAsync(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(existingBook);

            return NoContent();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
