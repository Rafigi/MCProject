namespace McWorld.Shared.ServicesBus
{
    using McWorld.Shared.Messages;
    using System.Threading.Tasks;
    public interface IServiceBus
    {
        Task Add<T>(T message) where T : IMessage;

        Task Complete();
    }
}
