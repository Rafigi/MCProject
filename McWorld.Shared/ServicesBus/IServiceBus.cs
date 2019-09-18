namespace MCAPI.McWorld.Shared.ServicesBus
{
    using MCAPI.McWorld.Shared.Messages;
    using System.Threading.Tasks;
    public interface IServiceBus : IMessage
    {
        Task Add<TMessage>(TMessage message) where TMessage : ICommand;

        Task Complete();
    }
}
