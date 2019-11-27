namespace McWorld.Shared.Messages
{
    using System.Threading.Tasks;
    public interface ICommandHandler<T>  where T : IMessage
    {
        Task ExecuteAsync(T message);
    }
}
