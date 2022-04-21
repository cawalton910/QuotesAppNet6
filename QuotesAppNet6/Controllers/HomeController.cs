using Microsoft.AspNetCore.Mvc;
using QuotesApp.Services;
using QuotesAppNet6.Models;
using System.Diagnostics;

namespace QuotesAppNet6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IQuoteRepository _quoteRepo;

    public HomeController(IQuoteRepository quoteRepo, ILogger<HomeController> logger)
    {
        _logger = logger;
        _quoteRepo = quoteRepo;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _quoteRepo.ReadAllAsync());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
