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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id); 
                entity.Property(e => e.ISBN).IsRequired().HasMaxLength(20); 
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100); 
                entity.Property(e => e.Genre).IsRequired().HasMaxLength(50); 
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500); 
                entity.Property(e => e.Author).IsRequired().HasMaxLength(100); 
                entity.Property(e => e.BookBorrowedTime).IsRequired();
                entity.Property(e => e.BookReturnDeadline).IsRequired(); 
            });
        }

    }
}