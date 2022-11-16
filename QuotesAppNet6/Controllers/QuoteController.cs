using Microsoft.AspNetCore.Mvc;
using QuotesApp.Models.Entities;
using QuotesApp.Services;

namespace QuotesAppNet6.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IQuoteRepository _quoteRepo;

        public QuoteController(IQuoteRepository quoteRepo)
        {
            _quoteRepo = quoteRepo;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAjax(Quote quote)
        {
            if (ModelState.IsValid)
            {
                await _quoteRepo.CreateAsync(quote);
                return Json(new { quoteId = quote.Id, message = "success" });
            }
            return Json("fail");
        }
        public async Task<IActionResult> QuoteRow(int id)
        {
            var quote = _quoteRepo.ReadAsync(id);
            return PartialView("/Views/Home/_QuoteRow.cshtml", quote);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
