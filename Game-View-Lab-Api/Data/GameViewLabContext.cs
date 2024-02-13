using Microsoft.EntityFrameworkCore;

public class GameViewLabContext : DbContext
{
    public DbSet<Game> Games {get; set;}

    public GameViewLabContext (DbContextOptions options) : base (options){}

}