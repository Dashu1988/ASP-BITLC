using BlogPostAnwendung.Models.Data;

namespace BlogPostAnwendung.Models
{
    public class BlogPostRepository : IBlogPostRepository
    {

        private readonly BlogDbContext _context;


        //private List<BlogPost> _blogPosts;

        //public BlogPostRepository()
        //{
        //    _blogPosts = new List<BlogPost>()
        //    {

        //        new BlogPost(){ Id = 1, Title = "Erster Blog Post",Content="Dies ist der Inhalt des Ersten Posts",CreatedAt = new DateTime(2023,10,26),Author="Max Msuetrmann"},
        //        new BlogPost(){ Id = 2, Title = "Zweiter Blog Post",Content="Dies ist der Inhalt des zweiten Posts",CreatedAt = new DateTime(2023,10,30),Author="Erika Musterfrau"},
        //        new BlogPost(){ Id = 3, Title = "Dritter Blog Post",Content="Dies ist der Inhalt des dritten Posts",CreatedAt = new DateTime(2023,7,26), Author="Max Musteres"}
        //    };
        //}

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
           // return _blogPosts.FirstOrDefault(i => i.Id == id);
        }
    }
}
