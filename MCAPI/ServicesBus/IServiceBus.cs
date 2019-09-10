using MCAPI.Commands;
using MCAPI.Messages;
using MCAPI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.ServicesBus
{
    public interface IServiceBus : IMessage
    {
        Task Add<TMessage>(TMessage message) where TMessage : ICommand;

        Task Complete();
    }
}
