using MCAPI.McContext;
using MCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.IRepository
{
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
