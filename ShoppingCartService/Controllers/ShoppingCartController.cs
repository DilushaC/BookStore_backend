using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ShoppingCartService.Repositories;
using ShoppingCartService.Models;
using MongoDB.Bson;

namespace ShoppingCartService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _repository;

        public ShoppingCartController(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(string userId)
        {
            var cart = await _repository.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddItem([FromBody] CartItem item, [FromQuery] string userId)
        {
            await _repository.AddItemToCartAsync(userId, item);
            return NoContent();
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveItem([FromQuery] string userId, [FromQuery] string bookId)
        {
            var objectId = new ObjectId(bookId);
            await _repository.RemoveItemFromCartAsync(userId, objectId);
            return NoContent();
        }
    }
}
