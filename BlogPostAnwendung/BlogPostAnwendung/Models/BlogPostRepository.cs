using BlogPostAnwendung.Models.Data;

namespace BlogPostAnwendung.Models
{
    public class BlogPostRepository : IBlogPostRepository
    {

        private readonly BlogDbContext _context;

        public BlogPostRepository(BlogDbContext context)
        {
            _context = context;
        }
        public List<BlogPost> GetAllBlogPosts() 
        { 
            return _context.BlogPosts.ToList();
            //return _blogPosts;
        }

        public BlogPost GetBlogPostById(int id)
        {
            return _context.BlogPosts.Find(id);
        }

        public void DeleteBlogPost(int id)
        {
            var blogPost = this.GetBlogPostById(id);
            if (blogPost != null)
            {
                _context.BlogPosts.Remove(blogPost);
            }
        }
    }
    
    
}
