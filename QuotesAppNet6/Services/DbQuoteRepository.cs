using Microsoft.EntityFrameworkCore;
using QuotesApp.Models.Entities;
using QuotesApp.Services;

namespace QuotesApp.Services;

public class DbQuoteRepository : IQuoteRepository
{
    private ApplicationDbContext _db;

    public DbQuoteRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ICollection<Quote>> ReadAllAsync()
    {
        return await _db.Quotes.ToListAsync();
    }

}
