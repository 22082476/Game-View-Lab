using Microsoft.EntityFrameworkCore;

public class GameFixture : GameViewLabFixture
{
    protected override void LoadData(DbContextOptions options)
    {
        var context = new GameViewLabContext (options);

        context.AddRange (new Game { Id = 1, Name = "The Finals"}, new Game { Id = 2, Name = "Grand Theft Auto Five"});

        context.SaveChanges();
    }
}