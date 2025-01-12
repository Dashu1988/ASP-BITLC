using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models;
using sql = ZooManagement.Models.SQLiteConn;

namespace ZooManagement.Controllers;

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
        Console.WriteLine("get");
        return View();
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

    [HttpGet]
    public IActionResult ShowAllZoos()
    {
        return View(sql.ReadAllZoo());
    }

    [HttpPost]
    public IActionResult ZooDetails(ZooData z)
    {
        return View(sql.ReadZoo(z.ZooID));
    }

    [HttpPost]
    public IActionResult WorldDetails(ZooData z)
    {
        List<Welt> temp = sql.ReadWorlds(z.ZooID);
        foreach (Welt w in temp)
        {
            w.Gehege = sql.ReadEnclosures(w.ID);
        }
        return View(temp);
    }
  
    

}