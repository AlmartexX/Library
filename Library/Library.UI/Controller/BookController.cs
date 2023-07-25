using Library.BLL.DTO;
using Library.BLL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
   // [Authorize]
    public class BookController:ControllerBase
    {
        
        private readonly IBookService _bookService;
        public BookController(IBookService service)
        {
            _bookService = service
                     ?? throw new ArgumentNullException();

        }

        [HttpGet]
        public async Task<ActionResult<BookDTO>> GetBooksAsync()
        {
            var events = await _bookService.GetBooksAsync();
            if (events == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No book in database.");
            }

            return StatusCode(StatusCodes.Status200OK, events);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBookByIdAsync(int? id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No books found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, book);

        }

        [HttpGet("isbn/{isbn}")]
        public async Task<ActionResult<BookDTO>> GetBookByISBNAsync(int? isbn)
        {
            var book = await _bookService.GetBookByISBNAsync(isbn);
            if (book == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No books found for isbn: {isbn}");
            }

            return StatusCode(StatusCodes.Status200OK, book);

        }

        [HttpPost]
        public async Task<ActionResult> CreateBookAsync(CreateBookDTO newBook)
        {


            var book = await _bookService.CreateBookAsync(newBook);


            if (book == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"{newBook.Name} could not be added.");
            }

            return StatusCode(StatusCodes.Status200OK, $"A new book has been created: {book.Name}");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBookAsync(UpdateBookDTO updateBook, int? id)
        {
            var book = await _bookService.UpdateBookAsync(updateBook, id);
            if (book == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"{updateBook.Name} could not be updated");
            }

            return StatusCode(StatusCodes.Status200OK, $"{updateBook.Name} successfully changed");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookAsync(int? id)
        {
            (bool status, string message) = await _bookService.DeleteBookAsync(id);
            if (status == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, message);
            }

            return StatusCode(StatusCodes.Status200OK, $"{id.Value} successfully deleted");
        }
    }
}
