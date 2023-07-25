using Library.BLL.AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Validation;
using Library.DAL.Interface;
using AutoMapper;
using Library.BLL.Interface;
using Library.DAL.Modell;
using Microsoft.Extensions.Logging;
using static Library.BLL.Validation.ValidationException;

namespace Library.BLL.Service
{
    public class BookService: IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;
        private readonly IValidationPipelineBehavior<CreateBookDTO, CreateBookDTO> _createBookValidator;
        private readonly IValidationPipelineBehavior<UpdateBookDTO, UpdateBookDTO> _updateBookValidator;
        private readonly IBookMapper _bookMapper;


        public BookService(
          IMapper mapper,
          IBookRepository bookRepository,
          ILogger<BookService> logger,
          IValidationPipelineBehavior<CreateBookDTO, CreateBookDTO> createBookValidator,
          IValidationPipelineBehavior<UpdateBookDTO, UpdateBookDTO> updateBookValidator,
          IBookMapper bookMapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createBookValidator = createBookValidator ?? throw new ArgumentNullException(nameof(createBookValidator));
            _updateBookValidator = updateBookValidator ?? throw new ArgumentNullException(nameof(updateBookValidator));
            _bookMapper = bookMapper;
        }

        public async Task<IEnumerable<BookDTO>> GetBooksAsync()
        {
            
                var books = await _bookRepository.GetAllAsync();

                return books.Select(book => _bookMapper.MapToDTO(book));
           
        }

        public async Task<BookDTO> GetBookByIdAsync(int? id)
        {
            var book = await _bookRepository.GetByIdAsync(id.Value);
            if (book == null)
            {
                throw new NotFoundException("No records with this id in database");
            }

            return _bookMapper.MapToDTO(book);
        }
        public async Task<BookDTO> GetBookByISBNAsync(int? isbn)
        {
            var book = await _bookRepository.GetBookByISBNAsync(isbn.Value);
            if (book == null)
            {
                throw new NotFoundException("No records with this ISBN in database");
            }

            return _bookMapper.MapToDTO(book);

        }

        public async Task<CreateBookDTO> CreateBookAsync(CreateBookDTO newBookDto)
        {
            _logger.LogInformation("--> Book started added process!");

            return await _createBookValidator.Process(newBookDto, async () =>
            {
                var book = _bookMapper.MapToEntity(newBookDto);
                await _bookRepository.CreateAsync(book);
                _logger.LogInformation("--> Book added!");

                return newBookDto;
            });
        }

        public async Task<UpdateBookDTO> UpdateBookAsync(UpdateBookDTO bookDTO, int? id)
        {
            _logger.LogInformation("--> Book started update process!");

            return await _updateBookValidator.Process(bookDTO, async () =>
            {
                var existingBook = await _bookRepository.GetByIdAsync(id.Value);
                _bookMapper.MapToEntity(bookDTO, existingBook);
                await _bookRepository.UpdateAsync(existingBook);
                _logger.LogInformation("--> Book updated!");

                return bookDTO;
            });

        }

        public async Task<(bool, string)> DeleteBookAsync(int? id)
        {
            _logger.LogInformation("--> Books started delete process!");
            var book = await _bookRepository.GetByIdAsync(id.Value);
            if (book == null)
            {
                throw new NotFoundException("No records with this id in database");
            }
            await _bookRepository.DeleteAsync(id.Value);
            _logger.LogInformation("--> Book deleted!");

            return (true, "Book got deleted.");
        }
    }
}
