using MCAPI.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAdresseRepository Adresses { get; }
        IEventRepository Events { get; }
        IRouteRepository Routes { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}
