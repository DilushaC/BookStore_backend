using System.Collections.Generic;
using System.Threading.Tasks;
using BookListService.Models;

namespace BookListService.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync(string filter, int page, int pageSize);
        Task<Book> GetBookByIdAsync(string id);
    }
}
