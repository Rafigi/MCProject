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

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }

        public Address GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
