using MCAPI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.Messages
{
    public interface IMessageHandler<in T>
    {
        Task Handler(T message);
    }
}
