namespace McWorld.User
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using McWorld.Shared.Persistence;
    using System.Threading.Tasks;

    public class CreateUserCommand : ICommand
    {
        public User _user { get; private set; }
        public CreateUserCommand(User user)
        {
            _user = new User()
            {
                UserID = user.UserID,
                Username = user.Username,
                Password = user.Password,
                Birthdate = user.Birthdate,
                Created = user.Created,
                Email = user.Email
            };

        }
        public Task Execute(IUnitOfWork unitOfWork)
        {
            unitOfWork.Users.Add(_user);
            return Task.CompletedTask;
        }
    }
}
