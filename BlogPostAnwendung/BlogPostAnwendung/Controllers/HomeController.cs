using BlogPostAnwendung.Models;
using BlogPostAnwendung.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogPostAnwendung.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private BlogPostRepository _blogPostRepository = new BlogPostRepository();
        private IBlogPostRepository _blogPostRepository;
        public HomeController(ILogger<HomeController> logger, IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var temp = _blogPostRepository.GetAllBlogPosts();
            return View(temp);
        }



        public IActionResult Details(int id)
        {
            return View(_blogPostRepository.GetBlogPostById(id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_blogPostRepository.GetBlogPostById(id));
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            
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
    }
}
