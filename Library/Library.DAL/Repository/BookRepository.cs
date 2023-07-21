using Library.DAL.Interface;
using Library.DAL.Modell;
using Library.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
       
            private readonly IAppContext _context;
            public BookRepository(IAppContext context) : base(context)
        {
                _context = context
                    ?? throw new ArgumentNullException();

            }

        //public async Task<IEnumerable<Book>> GetBooksAsync() =>
        //     await _context.Books
        //     .AsNoTracking()
        //     .ToListAsync();

        //public async Task<Book> GetBookByIdAsync(int id) =>
        //     await _context.Books
        //     .AsNoTracking()
        //     .FirstOrDefaultAsync(e => e.Id == id);

        //public async Task<Book> GetBookByISBNAsync(int isbn) =>
        //     await _context.Books
        //     .AsNoTracking()
        //     .FirstOrDefaultAsync(b => b.ISBN == isbn);


        //public async Task CreateBookAsync(Book bookToAdd)
        //{
        //    await _context.Books.AddAsync(bookToAdd);
        //    await _context.SaveChangesAsync();

        //}

        //public async Task UpdateBookAsync(Book bookToUpdate)
        //{
        //    _context.Books.Update(bookToUpdate);
        //    await _context.SaveChangesAsync();

        //}

        //public async Task DeleteBookAsync(int id)
        //{
        //    var bookToDelete = await _context.Books.FindAsync(id);
        //    _context.Books.Remove(bookToDelete);
        //    await _context.SaveChangesAsync();

        //}
        public async Task<Book> GetBookByISBNAsync(int isbn)
        {
            return await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.ISBN == isbn);
        }

    }
}
