namespace McWorld.User.Handler
{
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using System;
    using System.Threading.Tasks;
    class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory;

        public CreateUserCommandHandler(IUserRepository userRepository, IUserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }
        public Task ExecuteAsync(CreateUserCommand message)
        {
            var user = _userFactory.Create(message.User);
            _userRepository.Add(user);
            return Task.CompletedTask;
        }
    }
}
