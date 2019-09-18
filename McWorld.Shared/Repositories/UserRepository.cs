
namespace MCAPI.McWorld.Shared.Repository
{
    using MCAPI.McWorld.Shared.Data;
    using MCAPI.McWorld.Shared.IRepository;
    using MCAPI.McWorld.Shared.Models;
    using System;
    using System.Linq;
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(McDbContext context) : base(context)
        {
        }

        public string GetEmailByID(Guid id)
        {
            return McDbContext.Users.Single(x => x.UserID == id).Email;
        }

        public User GetUserByID(Guid id)
        {
            return McDbContext.Users.Single(x => x.UserID == id);
        }

        public string GetUsernameByID(Guid id)
        {
            return McDbContext.Users.Single(x => x.UserID == id).Username;
        }

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
