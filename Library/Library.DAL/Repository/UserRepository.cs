using Library.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Library.DAL.Context;
using Library.DAL.Modell;

namespace Library.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IAppContext _context;

        public UserRepository(IAppContext context)
        {
            _context = context 
                ?? throw new ArgumentNullException();

        }

        public async Task RegisterUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
        }

        public async Task<User> GetUserByName(string userName)=>
            await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == userName);

    }
}
