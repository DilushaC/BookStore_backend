using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookListService.Models;
using BookListService.Data;
using MongoDB.Bson;

namespace BookListService.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoDBContext _context;

        public BookRepository(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksAsync(string filter, int page, int pageSize)
        {
            var collection = _context.Books;
            var filterDefinition = Builders<Book>.Filter.Empty;

            if (!string.IsNullOrEmpty(filter))
            {
                filterDefinition = Builders<Book>.Filter.Regex("Title", new MongoDB.Bson.BsonRegularExpression(filter, "i"));
            }

            return await collection.Find(filterDefinition)
                                   .Skip((page - 1) * pageSize)
                                   .Limit(pageSize)
                                   .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            return await _context.Books.Find(b => b.Id == objectId).FirstOrDefaultAsync();
        }
    }
}
