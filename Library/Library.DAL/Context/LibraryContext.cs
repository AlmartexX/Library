using Library.DAL.Configuration;
using Library.DAL.Interface;
using Library.DAL.Modell;

using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Context
{
    public class LibraryContext : DbContext, IAppContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }

    }
}