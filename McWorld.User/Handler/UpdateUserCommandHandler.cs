namespace McWorld.McUser.Handler
{
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using McWorld.McUser.Commands;
    using System;
    using System.Threading.Tasks;
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>, ICommandHandler<UpdatePasswordCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task ExecuteAsync(UpdateUserCommand message)
        {
            var user = _userRepository.GetById(message.UserId);
            if (user == null) throw new ArgumentNullException($"There is no user with that id - {message.UserId}");

            user.UpdateMail(user.Email);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UpdatePasswordCommand message)
        {
            var user = _userRepository.GetById(message.Id);
            if (user == null) throw new ArgumentNullException($"There is no user with that id - {message.Id}");

            user.UpdatePassword(message.Password);
            return Task.CompletedTask;
        }
    }
}
