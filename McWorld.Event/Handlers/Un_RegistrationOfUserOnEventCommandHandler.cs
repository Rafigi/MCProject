namespace McWorld.McEvent.Handlers
{
    using McWorld.McEvent.Commands;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using System.Threading.Tasks;

    public class Un_RegistrationOfUserOnEventCommandHandler : ICommandHandler<RegisterUserOnEventCommand>, ICommandHandler<UnRegisterUserOnEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public Un_RegistrationOfUserOnEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task ExecuteAsync(RegisterUserOnEventCommand message)
        {
            _eventRepository.UnRegisterUser(message.UserId, message.EventId);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UnRegisterUserOnEventCommand message)
        {
            _eventRepository.RegisterUser(message.UserId, message.EventId);
            return Task.CompletedTask;
        }
    }
}