using MCAPI.Messages;
using MCAPI.Persistence;
using System.Threading.Tasks;

namespace MCAPI.Commands
{
    public interface ICommand : IMessage
    {
        Task Execute(IUnitOfWork unitOfWork);

    }
}
