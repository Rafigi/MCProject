namespace McWorld.McUser.Commands
{
    using McWorld.Shared.Messages;
    using System;

    public class DeleteUserCommand : ICommand
    {
        public Guid Id { get; }
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
