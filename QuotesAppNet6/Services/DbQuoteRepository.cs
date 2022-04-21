using Microsoft.EntityFrameworkCore;
using QuotesApp.Models.Entities;
using QuotesApp.Services;

namespace QuotesApp.Services;

public class DbQuoteRepository : IQuoteRepository
{
    private QuotesDbContext _db;

    public DbQuoteRepository(QuotesDbContext db)
    {
        _db = db;
    }

    public async Task<ICollection<Quote>> ReadAllAsync()
    {
        return await _db.Quotes.ToListAsync();
    }

}
