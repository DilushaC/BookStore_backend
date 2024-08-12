using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ShoppingCartService.Models
{
    public class ShoppingCart
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string UserId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        public ObjectId BookId { get; set; }
        public int Quantity { get; set; }
    }
}
