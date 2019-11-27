namespace McWorld.User.Commands
{
    using McWorld.Shared.Messages;
    using System;

    public class UpdateUserCommand : ICommand
    {
        public Guid UserId { get; private set; }
        public string Mail { get; private set; }

        public UpdateUserCommand(Guid userId, string mail)
        {
            UserId = userId;
            Mail = mail;
        }
    }
}
