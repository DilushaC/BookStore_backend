using System.Threading.Tasks;
using BookDetailsService.Models;

namespace BookDetailsService.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdAsync(string id);
    }
}
