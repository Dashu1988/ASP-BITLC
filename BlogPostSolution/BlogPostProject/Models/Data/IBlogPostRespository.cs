namespace BlogPostProject.Models.Data
{
    public interface IBlogPostRepository
    {
        List<BlogPost> GetAllBlogPosts();

        BlogPost GetBlogPostById(int id);
    }
}