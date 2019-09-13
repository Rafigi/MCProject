using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCAPI.Models;

namespace MCAPI.Factory
{
    public class UserFactory : IUserFactory
    {
        public User Create(User user)
        {
            return new User()
            {
                UserID = Guid.NewGuid(),
                Password = user.Password,
                Username = user.Username,
                Email = user.Email,
                Created = user.Created
            };
        }

        public User Update(User type)
        {
            throw new NotImplementedException();
        }
    }
}
