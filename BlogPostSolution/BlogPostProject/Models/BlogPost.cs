using System.Collections;
using Microsoft.EntityFrameworkCore;
namespace BlogPostProject.Models;

public class BlogPost
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime CreatedAt { get; set; }

   
}