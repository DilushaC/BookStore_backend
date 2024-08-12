using MongoDB.Driver;
using System.Threading.Tasks;
using BookDetailsService.Models;
using MongoDB.Bson;
using BookDetailsService.Data;

namespace BookDetailsService.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoDBContext _context;

        public BookRepository(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            return await _context.Books.Find(b => b.Id == objectId).FirstOrDefaultAsync();
        }
    }
}
