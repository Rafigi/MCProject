namespace McWorld.User.Commands
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using System;

    public class UpdatePasswordCommand : ICommand
    {
        public UpdatePasswordCommand(User user)
        {
            Password = user.Password;
            Id = user.UserID;
        }

        public string Password { get; private set; }
        public Guid Id { get; private set; }
    }
}
