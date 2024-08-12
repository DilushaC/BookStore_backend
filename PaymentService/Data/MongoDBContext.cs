using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using PaymentService.Models;

namespace PaymentService.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("MongoDB:ConnectionString"));
            _database = client.GetDatabase(configuration.GetValue<string>("MongoDB:DatabaseName"));
        }

        public IMongoCollection<Payment> Payments => _database.GetCollection<Payment>("Payments");
    }
}
