namespace MCAPI.McWorld.Shared.Persistence
{
    using MCAPI.McWorld.Shared.IRepository;
    using System;
    public interface IUnitOfWork : IDisposable
    {
        IAdresseRepository Adresses { get; }
        IEventRepository Events { get; }
        IRouteRepository Routes { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}
