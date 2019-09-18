
namespace MCAPI.McWorld.Shared.Factory
{
    using MCAPI.McWorld.Shared.Models;
    using System;
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
