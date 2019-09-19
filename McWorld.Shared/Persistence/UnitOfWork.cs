namespace McWorld.Shared.Persistence
{
    using McWorld.Shared.Data;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Repository;

    public class UnitOfWork : IUnitOfWork
    {
        //Variables
        private readonly McDbContext _context;

        //Interfaces
        public IAdresseRepository Adresses { get; private set; }
        public IEventRepository Events { get; private set; }
        public IRouteRepository Routes { get; private set; }
        public IUserRepository Users { get; private set; }

        public UnitOfWork(McDbContext context)
        {
            _context = context;
            Adresses = new AdresseRepository(_context);
            Events = new EventRepository(_context);
            Routes = new RouteRepository(_context);
            Users = new UserRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
