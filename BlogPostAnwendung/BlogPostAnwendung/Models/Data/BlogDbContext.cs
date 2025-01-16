using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace BlogPostAnwendung.Models.Data
{
    public class BlogDbContext : DbContext
    {

        public BlogDbContext(DbContextOptions<BlogDbContext> options)  : base(options)
        {
            // Hier werden Optionen bei der erstellung des Objektes 
            //BlogDbContext mitgeben, die Klasse DBContext besitzt einen Konstruktor der diese 
            //Optionen verarbeiten kann 

            // Was genau diese Klasse alles kann, ist nicht wirklich wichtig zu wissen. 
            
        }

        public DbSet<BlogPost> BlogPosts { get; set; } //
        //Das ist das wichtigste hier.
        //Ein DbSet repräsentiert eine Tabelle in der Datenbank.
        // In diesem Fall erstellen wir eine Tabelle BlogPosts, die unsere BlogPost-Objekte speichert.
    }
}
