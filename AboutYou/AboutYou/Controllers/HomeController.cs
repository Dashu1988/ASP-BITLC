using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AboutYou.Models;

namespace AboutYou.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View("Index");
    }

    public IActionResult Impressum()
    {
        return View("Impressum");
    }

    [HttpGet]
    public IActionResult AboutMe()
    {
        AboutMeViewModel model = new AboutMeViewModel();
        return View("AboutMe", model);
    }

    [HttpPost]
    public IActionResult AboutMe(AboutMeViewModel model)
    {
        return View("AboutMe", model);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}