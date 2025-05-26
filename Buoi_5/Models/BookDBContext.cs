using Microsoft.EntityFrameworkCore;


public class BookDBContext : DbContext
{
    public BookDBContext(DbContextOptions<BookDBContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    }
