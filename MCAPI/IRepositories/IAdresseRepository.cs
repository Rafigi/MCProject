using MCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.IRepository
{
    public interface IAdresseRepository : IRepository<Adresse>
    {
        Adresse GetAdresseByID(int id);
    }
}
