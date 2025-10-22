using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso> GetByIdAsync(int idCurso);
        Task AddAsync(Curso curso);
        Task UpdateAsync(Curso curso);
        Task DeleteAsync(int idCurso);
    }
}
