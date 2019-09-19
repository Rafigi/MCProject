namespace McWorld.Shared.ServicesBus
{
    using McWorld.Shared.Messages;
    using System.Threading.Tasks;
    public interface IServiceBus : IMessage
    {
        Task Add<TMessage>(TMessage message) where TMessage : ICommand;

        Task Complete();
    }
}
