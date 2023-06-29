
using Library.DAL.Modell;

namespace Library.DAL.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookByIdAsync(int id);

        Task<Book> GetBookByISBNAsync(int isbn);

        Task CreateBookAsync(Book book);

        Task UpdateBookAsync(Book book);

        Task DeleteBookAsync(int id);
    }
}
