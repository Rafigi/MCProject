namespace McWorld.Event.Handlers
{
    using McWorld.Event.Commands;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using System;
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
            var @event = _eventRepository.GetById(message.EventId);
            if (@event == null)
                throw new ArgumentNullException($"There is no Event with the Id {message.EventId}");

            @event.RegisterUser(message.EventId, message.UserId);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UnRegisterUserOnEventCommand message)
        {

            var @event = _eventRepository.GetById(message.EventId);
            if (@event == null)
                throw new ArgumentNullException($"There is no Event with the Id {message.EventId}");

            @event.UnRegisterUser(message.EventId, message.UserId);
            return Task.CompletedTask;
        }
    }
}
