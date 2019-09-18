namespace MCAPI.McWorld.Shared.Messages
{
    using MCAPI.McWorld.Shared.Persistence;
    using System.Threading.Tasks;
    public interface ICommand : IMessage
    {
        Task Execute(IUnitOfWork unitOfWork);

    }
}
