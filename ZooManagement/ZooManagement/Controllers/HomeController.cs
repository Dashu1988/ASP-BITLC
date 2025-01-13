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
    public IActionResult ZooDetails(ZooModel z)
    {
        return View(sql.ReadZoo(z.ZooID, true));
    }

    [HttpPost]
    public IActionResult WorldDetails(ZooModel z)
    {
       Zoo temp = sql.ReadZoo(z.ZooID, true);
        return View(temp);
    }

    [HttpPost]
    public IActionResult EnclosureDetails(ZooModel z)
    {
        z.zoo = sql.ReadZoo(z.ZooID, true);
        
        return View(z);
    }

    [HttpGet]
    public IActionResult AddAnimal()
    {
        return View(sql.ReadAnimalTypes());
    }

    [HttpPost]
    public IActionResult AddAnimal(AddAnimal aa)
    {
        //TODO: EVERYTHING ABOUT THIS IS FUCKED
        Console.WriteLine(aa.Name);
        return RedirectToAction("ShowAllZoos");
    }
  
    

}