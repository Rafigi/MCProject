namespace McWorld.Shared.IRepository
{
    using McWorld.Shared.Models;
    using System;
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByID(Guid id);
        string GetUsernameByID(Guid id);
        string GetEmailByID(Guid id);
    }
}
