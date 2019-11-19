﻿namespace McWorld.Shared.Repository
{
    using McWorld.Shared.Data;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
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

        public User GetByID(Guid id)
        {
            return McDbContext.Users.Single(x => x.UserID == id);
        }

        public string GetUsernameByID(Guid? id)
        {
            return McDbContext.Users.Single(x => x.UserID == id).Username;
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetByMail(string mail)
        {
            throw new NotImplementedException();
        }

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
