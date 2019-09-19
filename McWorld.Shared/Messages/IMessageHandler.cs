namespace McWorld.Shared.Messages
{
    using System.Threading.Tasks;
    public interface IMessageHandler<in T>
    {
        Task Handler(T message);
    }
}
