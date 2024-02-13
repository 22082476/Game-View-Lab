using Microsoft.EntityFrameworkCore;

public abstract class GameViewLabFixture : IDisposable
{
        private bool _disposed;

        public GameViewLabContext Context { get; private set; }
        public GameViewLabContext ContextWithout { get; private set; }

        public GameViewLabFixture()
        {
            var options = new DbContextOptionsBuilder<GameViewLabContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            Context = new GameViewLabContext(options);

            // Voeg testgegevens toe aan de context
            LoadData(options);


            var options2 = new DbContextOptionsBuilder<GameViewLabContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            ContextWithout = new GameViewLabContext(options2);
        }

        protected virtual void LoadData (DbContextOptions options){}

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Opruimen van resources indien nodig
                    Context.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
}