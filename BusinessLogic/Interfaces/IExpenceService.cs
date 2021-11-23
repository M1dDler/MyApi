using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IExpenceService
    {
        Task<IEnumerable<ExpenceHeader>> GetExpencesAsync();
        Task<ExpenceHeader> GetExpenceByIdAsync(int id);
        Task CreateExpence(ExpenceHeader expenceHeader);
    }


}
