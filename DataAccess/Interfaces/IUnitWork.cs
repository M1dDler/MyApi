using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUnitWork
    {
        Task CommitAsync();
    }

}
