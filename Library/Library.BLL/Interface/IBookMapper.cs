
using Library.BLL.DTO;
using Library.DAL.Modell;

namespace Library.BLL.Interface
{
    public interface IBookMapper
    {
        BookDTO MapToDTO(Book book);
        Book MapToEntity(CreateBookDTO newBookDto);
        void MapToEntity(UpdateBookDTO bookDTO, Book existingBook);
    }
}
