using MCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByID(Guid id);
        string GetUsernameByID(Guid id);
        string GetEmailByID(Guid id);
    }
}
