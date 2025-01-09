using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers;

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

    public IActionResult ToDoShow()
    {
        return View(ToDoTask.AllTasks);
    }

    [HttpPost]
    public IActionResult ToDoChange(ToDoTask t)
    {
        foreach (ToDoTask tt in ToDoTask.AllTasks)
        {
            if (t == tt)
            {
                tt.done = !(tt.done);
                return RedirectToAction("ToDoShow");

            }
        }

        return RedirectToAction("ToDoShow");
    }

    [HttpPost]
    public IActionResult ToDoDelete(ToDoTask t)
    {
        foreach (ToDoTask tt in ToDoTask.AllTasks)
        {
            if (t == tt)
            {
                ToDoTask.AllTasks.Remove(tt);
                return RedirectToAction("ToDoShow");
            }
        }

        return RedirectToAction("ToDoShow");
    }

    [HttpGet]
    public IActionResult ToDoForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ToDoForm(ToDoTask t)
    {
        ToDoTask.AllTasks.Add(t);
        return RedirectToAction("ToDoShow");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}