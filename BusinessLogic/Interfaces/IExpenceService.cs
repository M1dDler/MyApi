using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IExpenceService
    {
        Task<IEnumerable<ExpenceDatail>> GetExpencesAsync();
        Task<ExpenceDatail> GetExpenceByIdAsync(int id);
        Task CreateExpence();
    }

}
