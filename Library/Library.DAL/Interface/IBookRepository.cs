
using Library.DAL.Modell;

namespace Library.DAL.Interface
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book> GetBookByISBNAsync(int isbn);
    }
}
