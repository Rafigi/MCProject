using MCAPI.Models;
using System;

namespace MCAPI.IRepository
{
    public interface IAdresseRepository : IRepository<Address>
    {
        Address GetAdresseByID(Guid id);
    }
}
