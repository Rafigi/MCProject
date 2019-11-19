namespace McWorld.User.Commands
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    public class UpdateUserCommand : ICommand
    {
        public User User { get; }
        public UpdateUserCommand(User user)
        {
            User = user;
        }
    }
}
