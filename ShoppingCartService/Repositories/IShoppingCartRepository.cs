using System.Threading.Tasks;
using MongoDB.Bson;
using ShoppingCartService.Models;

namespace ShoppingCartService.Repositories
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetCartByUserIdAsync(string userId);
        Task AddItemToCartAsync(string userId, CartItem item);
        Task RemoveItemFromCartAsync(string userId, ObjectId bookId);
    }
}
