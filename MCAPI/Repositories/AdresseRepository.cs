using MCAPI.McContext;
using MCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.IRepository
{
    public class AdresseRepository : Repository<Adresse>, IAdresseRepository
    {
        public AdresseRepository(McDbContext context) : base(context)
        {
        }

        public Adresse GetAdresseByID(int id)
        {
            throw new NotImplementedException();
        }

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
