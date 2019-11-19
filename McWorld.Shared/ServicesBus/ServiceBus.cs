namespace McWorld.Shared.ServicesBus
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Persistence;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class ServiceBus : IServiceBus
    {
        private readonly IList<IMessage> _messages;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceBus(IUnitOfWork unitOfWork)
        {
            _messages = new List<IMessage>();
            _unitOfWork = unitOfWork;
        }

        public Task Add<T>(T message) where T : IMessage
        {
            _messages.Add(message);
            return Task.CompletedTask;
        }

        public async Task Complete()
        {
            _unitOfWork.Complete();
            await Task.CompletedTask;
        }
    }
}
