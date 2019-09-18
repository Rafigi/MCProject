
namespace MCAPI.McWorld.Shared.Repository
{
    using MCAPI.McWorld.Shared.Data;
    using MCAPI.McWorld.Shared.IRepository;
    using MCAPI.McWorld.Shared.Models;
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
