using MCAPI.Commands;
using MCAPI.Messages;
using MCAPI.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.ServicesBus
{
    public class ServiceBus : IServiceBus
    {
        private readonly IList<ICommand> _messages;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceBus(IUnitOfWork unitOfWork)
        {
            _messages = new List<ICommand>();
            _unitOfWork = unitOfWork;
        }

        public Task Add<TMessage>(TMessage message) where TMessage : ICommand
        {
            _messages.Add(message);
            return Task.CompletedTask;
        }

        public Task Complete()
        {
            foreach (var message in _messages)
            {
                message.Execute(_unitOfWork);
            }
            _unitOfWork.Complete();
            return Task.CompletedTask;
        }
    }
}
