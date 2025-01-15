using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_Test.Models;

namespace ASP_Test.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        test t = new test();
        for (int i = 0; i < 10; i++)
        {
            t.numbers.Add(i);
        }
        return View(t);
    }

    [HttpPost]
    public IActionResult Index(test x)
    {
        return View(x);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}