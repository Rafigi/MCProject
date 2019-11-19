namespace McWorld.User.Commands
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    public class DeleteUserCommand : ICommand
    {
        public User User { get; }
        public DeleteUserCommand(User user)
        {
            User = user;
        }
    }
}
