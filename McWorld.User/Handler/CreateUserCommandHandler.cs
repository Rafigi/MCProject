namespace McWorld.User.Handler
{
    using McWorld.User.Commands;
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Queryables;
    using System;
    using System.Threading.Tasks;
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory;
        private readonly IUserQueryables _userQueryables;

        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IUserFactory userFactory,
            IUserQueryables userQueryables
            )
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
            _userQueryables = userQueryables;
        }
        public Task ExecuteAsync(CreateUserCommand message)
        {
            var user = _userFactory.Create(message.User);
            _userRepository.Add(user);
            return Task.CompletedTask;
        }
    }
}
