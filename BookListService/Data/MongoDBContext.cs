using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using BookListService.Models;

namespace BookListService.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("MongoDB:ConnectionString"));
            _database = client.GetDatabase(configuration.GetValue<string>("MongoDB:DatabaseName"));
        }

        public IMongoCollection<Book> Books => _database.GetCollection<Book>("Books");
    }
}
