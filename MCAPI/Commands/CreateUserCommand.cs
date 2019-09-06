using MCAPI.Models;
using MCAPI.Persistence;
using System;

namespace MCAPI.Commands
{
    public class CreateUserCommand : ICommand
    {
        private readonly IUnitOfWork _unitOfWork;
        public User User { get; private set; }


        public CreateUserCommand(User user, IUnitOfWork unitOfWork)
        {
            User = new User()
            {
                UserID = Guid.NewGuid(),
                Password = user.Password,
                Username = user.Username,
                Email = user.Email,
                Created = user.Created
            };
            _unitOfWork = unitOfWork;
        }

        public void Execute()
        {
            _unitOfWork.Users.Add(User);
            _unitOfWork.Complete();
        }
    }


}

