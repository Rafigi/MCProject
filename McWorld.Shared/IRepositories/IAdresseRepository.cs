
namespace MCAPI.McWorld.Shared.IRepository
{
    using MCAPI.McWorld.Shared.Models;
    using System;
    public interface IAdresseRepository : IRepository<Address>
    {
        Address GetAdresseByID(Guid id);
    }
}
