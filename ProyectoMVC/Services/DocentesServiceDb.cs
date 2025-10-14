using Data;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class DocentesServiceDb : IDocentesService
    {
        private readonly IDocentesRepository _repository;

        public DocentesServiceDb(IDocentesRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Docentes>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Docentes> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Docentes docente) => _repository.AddAsync(docente);
        public Task UpdateAsync(Docentes docente) => _repository.UpdateAsync(docente);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
