﻿namespace McWorld.Shared.Factory
{
    using McWorld.Shared.Models;
    using System;

    class UserFactory : IUserFactory
    {
        public User Create(User user)
        {
            return new User()
            {
                UserID = Guid.NewGuid(),
                Password = user.Password,
                Username = user.Username,
                Birthdate = user.Birthdate,
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
