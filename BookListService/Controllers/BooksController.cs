using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BookListService.Repositories;
using BookListService.Models;

namespace BookListService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] string filter = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var books = await _repository.GetBooksAsync(filter, page, pageSize);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {
            var book = await _repository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
