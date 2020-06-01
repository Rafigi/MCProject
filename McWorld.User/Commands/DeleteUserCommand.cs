namespace McWorld.User.Commands
{
    using McWorld.Shared.Messages;
    using System;

    public class DeleteUserCommand : ICommand
    {
        public Guid UserId { get; }
        public DeleteUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
