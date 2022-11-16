using QuotesApp.Models.Entities;

namespace QuotesApp.Services;

public interface IQuoteRepository
{
    Task<ICollection<Quote>> ReadAllAsync();
    Task<Quote> CreateAsync(Quote quote);
    Task<Quote?> ReadAsync(int id);
}
