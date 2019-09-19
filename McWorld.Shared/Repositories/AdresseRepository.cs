namespace McWorld.Shared.Repository
{
    using McWorld.Shared.Data;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using System;
    public class AdresseRepository : Repository<Address>, IAdresseRepository
    {
        public AdresseRepository(McDbContext context) : base(context)
        {
        }

        public Address GetAdresseByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
