namespace McWorld.User
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;

    public class CreateUserCommand : ICommand
    {
        public CreateUserCommand(User user)
        {
            User = user;
        }

        public User User { get; }
    }
}
