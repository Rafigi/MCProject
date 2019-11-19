namespace McWorld.Shared.IRepository
{
    using McWorld.Shared.Models;
    using System;
    public interface IUserRepository : IRepository<User>
    {
        User GetById(Guid id);
        User GetByMail(string mail);
    }
}
