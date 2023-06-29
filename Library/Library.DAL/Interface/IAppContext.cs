﻿using Library.DAL.Modell;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Interface
{
    public interface IAppContext : IDisposable
    {
        DbSet<Book> Books { get; }
        DbSet<User> Users { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
