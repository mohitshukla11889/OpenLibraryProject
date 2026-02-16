using Microsoft.AspNetCore.Mvc;
using OpenLibrary.Services;

namespace OpenLibrary.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] int limit = 10, [FromQuery] int offset = 0)
        {
            if (limit == 0)
                return BadRequest("Limit must be greater than zero.");

            var result = await _service.GetBooksAsync(limit, offset);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("Title is required.");

            var result = await _service.SearchAsync(title);
            return Ok(result);
        }
    }
}