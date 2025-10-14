using Data;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ColegioServiceDb : IColegioService
    {
        private readonly IColegioRepository _repository;

        public ColegioServiceDb(IColegioRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Colegio>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Colegio> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Colegio colegio) => _repository.AddAsync(colegio);
        public Task UpdateAsync(Colegio colegio) => _repository.UpdateAsync(colegio);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
