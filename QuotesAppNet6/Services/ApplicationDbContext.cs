using QuotesApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace QuotesApp.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Quote> Quotes => Set<Quote>();
}
