﻿using MCAPI.McContext;
using MCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MCAPI.IRepository
{
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
