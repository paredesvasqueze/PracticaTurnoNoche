using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IDocentesRepository
    {
        Task<IEnumerable<Docentes>> GetAllAsync();
        Task<Docentes> GetByIdAsync(int id);
        Task AddAsync(Docentes docente);
        Task UpdateAsync(Docentes docente);
        Task DeleteAsync(int id);
    }
}
