using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Party.Models;
using System.Linq;

namespace Party.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public ViewResult Index()
    {
        ViewBag.Hour = DateTime.Now.Hour;
        ViewBag.Minute = DateTime.Now.Minute;
        
        ViewBag.Greeting = ViewBag.hour < 12 ? "Good Morning" : "Good Afternoon";
        ViewBag.CurrentTime = DateTime.Now.ToString("HH:mm:ss");
        return View();
    }

    [HttpGet]
    public ViewResult RsvpForm()
    {
        return View();
    }

    [HttpPost]
    public ViewResult RsvpForm(GuestResponse guestResponse)
    {
        if (ModelState.IsValid)
        {
            Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse);
        }
        else
        {
            return View();
        }
    }
    public IActionResult Privacy()
    {
        return View();
    }

    
    public ViewResult ListResponses()
    {
        return View(Repository.Responses.Where(x => x.WillAttend == true));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}