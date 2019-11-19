namespace McWorld.User.Handler
{
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using McWorld.User.Commands;
    using System;
    using System.Threading.Tasks;
    class UpdateUserMailCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserMailCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task ExecuteAsync(UpdateUserCommand message)
        {
            var user = _userRepository.GetById(message.User.UserID);
            
            return Task.CompletedTask;
        }
    }
}
