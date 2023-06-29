
using Library.BLL.DTO;

namespace Library.BLL.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int? id);
        Task<BookDTO> GetBookByISBNAsync(int? isbn);
        Task<CreateBookDTO> CreateBookAsync(CreateBookDTO book);
        Task<UpdateBookDTO> UpdateBookAsync(UpdateBookDTO bookDTO, int? id);
        Task<(bool, string)> DeleteBookAsync(int? id);
    }
}
