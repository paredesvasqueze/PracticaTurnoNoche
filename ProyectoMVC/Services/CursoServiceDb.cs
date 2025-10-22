using Data;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CursoServiceDb : ICursoService
    {
        private readonly ICursoRepository _repository;
        public CursoServiceDb(ICursoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Curso>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Curso> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddAsync(Curso curso) => _repository.AddAsync(curso);

        public Task UpdateAsync(Curso curso) => _repository.UpdateAsync(curso);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
