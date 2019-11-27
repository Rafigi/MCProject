namespace McWorld.Shared.IRepository
{
    using McWorld.Shared.Models;
    using System;
    public interface IAdresseRepository : IRepository<Address>
    {
        Address GetById(Guid id);
    }
}
