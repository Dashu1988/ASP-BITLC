using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Einkaufsliste.Models;
using Microsoft.AspNetCore.Authentication;

namespace Einkaufsliste.Controllers;

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
        return View();
    }

    public IActionResult Angelegt(Position p)
    {
        
        return View();
    }

    public IActionResult ArtikelAnsehen()
    {
        List<Position> p = Repository.Pos;
        return View(p);
    }

    [HttpGet]
    public IActionResult ArtikelForm()
    {
        
        return View();
    }

    [HttpPost]
    public IActionResult ArtikelForm(Position p)
    {
        if (ModelState.IsValid) {
            SQLiteConn.InsertData(p);
            SQLiteConn.ReadData();
            foreach (Position pos in Repository.Pos)
            {
                if (pos.Name == p.Name && pos.Shop == p.Shop)
                {
                    return View("Angelegt", pos);
                }
            }
            return RedirectToAction("ArtikelAnsehen");
        } else {
            return View();
        }
        
    }
    
    public IActionResult ArtikelLöschen(Position p)
    {
        SQLiteConn.DeleteData(p);
        SQLiteConn.ReadData();
        return  RedirectToAction("ArtikelAnsehen");
    }

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}