using BlogPostProject.Models.Data;

namespace BlogPostProject.Models;

public class BlogPostRepository : IBlogPostRepository
{
    private List<BlogPost> _blogPosts = new();

    public List<BlogPost> GetAllBlogPosts()
    {
        return _blogPosts;
    }

    public BlogPostRepository()
    {
        _blogPosts = new List<BlogPost>()
        {
            new BlogPost(){Id = 1, Title = "Warum Hunde mehr Leckerchen bekommen sollten!", Content = "Weil ein zufriedener Hund nur halb so oft die Post frisst!", CreatedAt = new DateTime(2023,10,26), Author = "John"},
            new BlogPost(){Id = 2, Title = "100 Gründe gegen Hunde!", Content = "Zum Glück fallen uns nur 99 ein – Grund 100 ist ihre unendliche Niedlichkeit.", CreatedAt = new DateTime(2023,10,27), Author = "Trulli"},
            new BlogPost(){Id = 3, Title = "Wüste ist geil!", Content = "Weil man dort endlich seine Sandburgträume verwirklichen kann!", CreatedAt = new DateTime(2023,10,28), Author = "Die Leos"},
            new BlogPost(){Id = 4, Title = "Lasagne für die Seele", Content = "Nichts wärmt das Herz besser als geschichteter Käse!", CreatedAt = new DateTime(2023,10,29), Author = "John"},
            new BlogPost(){Id = 5, Title = "Katzenvideos: Unterschätzte Kunstform", Content = "Sie sind die Mona Lisa der modernen Zeit - wer kann da widerstehen?", CreatedAt = new DateTime(2023,10,30), Author = "Trulli"},
            new BlogPost(){Id = 6, Title = "Zuckerwatte oder Zuckerwut?", Content = "Die süßeste Aggression, die du jemals erleben wirst!", CreatedAt = new DateTime(2023,10,31), Author = "Die Leos"},
            new BlogPost(){Id = 7, Title = "Die geheimen Abenteuer von Pfannkuchen", Content = "Dieser flauschige Held denkt nicht daran, sich wenden zu lassen!", CreatedAt = new DateTime(2023,11,01), Author = "John"},
            new BlogPost(){Id = 8, Title = "Ein Leben voller Kaffeebohnen", Content = "Bohnen für Bohnen: Mein Weg zum Koffeingipfel!", CreatedAt = new DateTime(2023,11,02), Author = "Trulli"},
            new BlogPost(){Id = 9, Title = "Warum Einhorn-Pyjamas alles besser machen", Content = "Weil Magie immer im Kleiderschrank beginnt!", CreatedAt = new DateTime(2023,11,03), Author = "Die Leos"},
            new BlogPost(){Id = 10, Title = "Warum Pizza eine eigene Lebensmittelgruppe sein sollte", Content = "Weil Gemüse ein Nährstoff und Pizza ein Lebensstil ist!", CreatedAt = new DateTime(2023,11,04), Author = "John"},
            new BlogPost(){Id = 11, Title = "Die Kunst des Burger-Bauens", Content = "Ein Burger ohne Käse ist wie ein Himmel ohne Sterne.", CreatedAt = new DateTime(2023,11,05), Author = "Trulli"},
            new BlogPost(){Id = 12, Title = "Warum Käsesorten ihre eigenen Feiertage brauchen", Content = "Weil selbst Käse ein Argument ist, 'mehrere' Feiertage zu haben!", CreatedAt = new DateTime(2023,11,06), Author = "Die Leos"},
            new BlogPost(){Id = 13, Title = "Vergiss nicht den Nachtisch!", Content = "Ein Essen ohne Nachtisch ist wie ein Anzug ohne Krawatte.", CreatedAt = new DateTime(2023,11,07), Author = "John"},
            new BlogPost(){Id = 14, Title = "Die Wahrheit über Einhörner und Regenbögen", Content = "Einhörner sind eigentlich nur Pferde mit einem geheimen Karottenvorrat!", CreatedAt = new DateTime(2023,11,08), Author = "Trulli"},
            new BlogPost(){Id = 15, Title = "Socken: Warum sie immer verschwinden", Content = "Weil Socken einfach die geheimen Nomaden des Kleiderschranks sind.", CreatedAt = new DateTime(2023,11,09), Author = "Die Leos"},
            new BlogPost(){Id = 16, Title = "Kaffee: Der wahre Held des Morgens", Content = "Der einzige Held, der jeden Morgen zur Rettung kommt.", CreatedAt = new DateTime(2023,11,10), Author = "John"},
            new BlogPost(){Id = 17, Title = "Pyjamapartys sind nicht nur für Kinder", Content = "Weil Erwachsene auch mal eine Flucht vor der Realität brauchen!", CreatedAt = new DateTime(2023,11,11), Author = "Trulli"},
            new BlogPost(){Id = 18, Title = "Warum Pflanzen sprechen sollten", Content = "Damit dein Ficus endlich über dein Giessverhalten meckern kann.", CreatedAt = new DateTime(2023,11,12), Author = "Die Leos"}

        };
    }

    public BlogPost GetBlogPostById(int id)
    {
        return _blogPosts.FirstOrDefault(p => p.Id == id);
    }
}