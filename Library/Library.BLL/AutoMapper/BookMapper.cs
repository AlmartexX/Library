
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Interface;
using Library.DAL.Modell;

namespace Library.BLL.AutoMapper
{
    public class BookMapper : IBookMapper
    {
        private readonly IMapper _mapper;

        public BookMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public BookDTO MapToDTO(Book book)
        {
            return _mapper.Map<BookDTO>(book);
        }

        public Book MapToEntity(CreateBookDTO newBookDto)
        {
            return _mapper.Map<Book>(newBookDto);
        }

        public void MapToEntity(UpdateBookDTO bookDTO, Book existingBook)
        {
            _mapper.Map(bookDTO, existingBook);
        }

    }
}
