using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Taschenrechner.Models;

namespace Taschenrechner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(CalcOper c)
    {
        c.Calc();
        if (c.res != null)
        {
            CalcOper.AllOpers.Add(c);
        }
        
        return View(c);
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