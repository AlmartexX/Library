using Library.DAL.Modell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DAL.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ISBN).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Genre).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Author).IsRequired().HasMaxLength(100);
            builder.Property(e => e.BookBorrowedTime).IsRequired();
            builder.Property(e => e.BookReturnDeadline).IsRequired();
        }
    }
}
