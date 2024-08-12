using MongoDB.Driver;
using System.Threading.Tasks;
using ShoppingCartService.Models;
using ShoppingCartService.Data;
using MongoDB.Bson;

namespace ShoppingCartService.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly MongoDBContext _context;

        public ShoppingCartRepository(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<ShoppingCart> GetCartByUserIdAsync(string userId)
        {
            return await _context.ShoppingCarts.Find(c => c.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task AddItemToCartAsync(string userId, CartItem item)
        {
            var cart = await GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new ShoppingCart { UserId = userId };
                await _context.ShoppingCarts.InsertOneAsync(cart);
            }

            var existingItem = cart.Items.Find(i => i.BookId == item.BookId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cart.Items.Add(item);
            }

            await _context.ShoppingCarts.ReplaceOneAsync(c => c.UserId == userId, cart);
        }

        public async Task RemoveItemFromCartAsync(string userId, ObjectId bookId)
        {
            var cart = await GetCartByUserIdAsync(userId);
            if (cart != null)
            {
                cart.Items.RemoveAll(i => i.BookId == bookId);
                await _context.ShoppingCarts.ReplaceOneAsync(c => c.UserId == userId, cart);
            }
        }
    }
}
