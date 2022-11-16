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

    public async Task<Quote> CreateAsync(Quote quote)
    {
        await _db.Quotes.AddAsync(quote);
        await _db.SaveChangesAsync();
        return quote;
    }

    public async Task<ICollection<Quote>> ReadAllAsync()
    {
        return await _db.Quotes.ToListAsync();
    }

    public async Task<Quote?> ReadAsync(int id)
    {
        return await _db.Quotes.FirstOrDefaultAsync(a => a.Id == id);
    }
}
