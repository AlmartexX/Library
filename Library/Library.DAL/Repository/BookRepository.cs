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

        public async Task<Book> GetBookByISBNAsync(int isbn)
        {
            return await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.ISBN == isbn);
        }

    }
}
