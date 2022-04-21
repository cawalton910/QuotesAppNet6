using QuotesApp.Models.Entities;

namespace QuotesApp.Services;

public interface IQuoteRepository
{
    Task<ICollection<Quote>> ReadAllAsync();
}
