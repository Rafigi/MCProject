namespace McWorld.User.Handler
{
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using McWorld.User.Commands;
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

            _userRepository.Update(user);
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
