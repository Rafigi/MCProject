namespace McWorld.Shared.Repository
{
    using McWorld.Shared.Data;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using System;
    using System.Linq;
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(McDbContext context) : base(context)
        {
        }
        public User GetById(Guid id)
        {
            return McDbContext.Users.SingleOrDefault(x => x.UserID == id);
        }
        public User GetByMail(string mail)
        {
            return McDbContext.Users.SingleOrDefault(x => x.Email == mail);
        }

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
