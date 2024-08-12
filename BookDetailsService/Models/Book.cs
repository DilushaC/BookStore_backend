using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookDetailsService.Models
{
    public class Book
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublishedDate { get; set; }
        public decimal Price { get; set; }
    }
}
