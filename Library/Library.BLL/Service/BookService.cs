using Library.BLL.AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Validation;
using Library.DAL.Interface;
using AutoMapper;
using Library.BLL.Interface;
using Library.DAL.Modell;

namespace Library.BLL.Service
{
    public class BookService: IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookService(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException();

            _bookRepository = bookRepository
                ?? throw new ArgumentNullException();

        }

        public async Task<IEnumerable<BookDTO>> GetBooksAsync()
        {
            try
            {
                var books = await _bookRepository.GetBooksAsync();
                return _mapper.Map<IEnumerable<BookDTO>>(books);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<BookDTO> GetBookByIdAsync(int? id)
        {
            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id.Value);
                return _mapper.Map<BookDTO>(book);
            }
            catch (Exception ex)
            {

                return null;
            }
        } 
        public async Task<BookDTO> GetBookByISBNAsync(int? isbn)
        {
            try
            {
                var book = await _bookRepository.GetBookByISBNAsync(isbn.Value);
                return _mapper.Map<BookDTO>(book);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<CreateBookDTO> CreateBookAsync(CreateBookDTO newBookDto)
        {
            try
            {
                var validator = new CreateBookValidator();
                var result = validator.Validate(newBookDto);
                if (!result.IsValid)
                {
                    throw new ValidationException("The entry is incorrect");
                }
                var book = _mapper.Map<Book>(newBookDto);
                await _bookRepository.CreateBookAsync(book);
                return newBookDto;
            }
           
            catch (Exception)
            {
                
                return null;
            }

        }

        public async Task<UpdateBookDTO> UpdateBookAsync(UpdateBookDTO bookDTO, int? id)
        {
            try
            {
                var existingBook = await _bookRepository.GetBookByIdAsync(id.Value);
                var validator = new UpdateBookValidator();

                var result = validator.Validate(bookDTO);

                if (!result.IsValid)
                {
                    throw new ValidationException("The entry is incorrect");
                }
                var updatedBook = _mapper.Map<Book>(bookDTO);

                updatedBook.Id = existingBook.Id;

                await _bookRepository.UpdateBookAsync(updatedBook);
                return bookDTO;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<(bool, string)> DeleteBookAsync(int? id)
        {
            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id.Value);
                if (book == null)
                {
                    return (false, "Books could not be found");
                }
                await _bookRepository.DeleteBookAsync(id.Value);
                return (true, "Book got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }

        }
    }
}
