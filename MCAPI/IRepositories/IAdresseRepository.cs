using MCAPI.Models;

namespace MCAPI.IRepository
{
    public interface IAdresseRepository : IRepository<Adresse>
    {
        Adresse GetAdresseByID(int id);
    }
}
