using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogPostProject.Models;

namespace BlogPostProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BlogPostRepository _blogPostRepository = new BlogPostRepository();
    
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new BlogPostRepository().GetAllBlogPosts());
    }

    public IActionResult Details(int Id)
    {
        return View(_blogPostRepository.GetBlogPostById(Id));
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