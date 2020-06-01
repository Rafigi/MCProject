namespace McWorld.User.Handler
{
    using McWorld.User.Commands;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using System.Threading.Tasks;

    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task ExecuteAsync(DeleteUserCommand message)
        {
            var user = _userRepository.GetById(message.UserId);
            _userRepository.Remove(user);
            return Task.CompletedTask;
        }
    }
}
