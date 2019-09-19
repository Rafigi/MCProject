namespace McWorld.Shared.Messages
{
    using McWorld.Shared.Persistence;
    using System.Threading.Tasks;
    public interface ICommand : IMessage
    {
        Task Execute(IUnitOfWork unitOfWork);

    }
}
