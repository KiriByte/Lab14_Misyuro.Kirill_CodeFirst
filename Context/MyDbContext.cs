using Lab14_Misyuro.Kirill_CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;


namespace Lab14_Misyuro.Kirill_CodeFirst.Context;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public virtual DbSet<Book> Books { get; set; }
    
}