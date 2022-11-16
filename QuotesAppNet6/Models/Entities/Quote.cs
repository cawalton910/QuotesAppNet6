using Microsoft.Build.Framework;

namespace QuotesApp.Models.Entities;

public class Quote
{
    public int Id { get; set; }
    [Required]
    public string TheQuote { get; set; } = String.Empty;
    [Required]
    public string WhoSaidIt { get; set; } = String.Empty;
}
