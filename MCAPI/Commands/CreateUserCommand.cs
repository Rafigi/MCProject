using MCAPI.Models;
using MCAPI.Persistence;
using System;
using System.Threading.Tasks;

namespace MCAPI.Commands
{
    public class CreateUserCommand : ICommand
    {
        public User User { get; private set; }

        public CreateUserCommand(User user)
        {
            User = new User()
            {
                UserID = Guid.NewGuid(),
                Password = user.Password,
                Username = user.Username,
                Email = user.Email,
                Created = user.Created
            };
        }

        public Task Execute(IUnitOfWork unitOfWork)
        {
            unitOfWork.Users.Add(User);
            return Task.CompletedTask;
        }
    }
}

