using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso> GetByIdAsync(int id);
        Task AddAsync(Curso curso);
        Task UpdateAsync(Curso curso);
        Task DeleteAsync(int id);
    }
}
