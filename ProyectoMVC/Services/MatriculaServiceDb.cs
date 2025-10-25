using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class MatriculaServiceDb : IMatriculaService
    {
       private readonly IMatriculaRepository _repository;

        public MatriculaServiceDb(IMatriculaRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Matricula>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Matricula> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Matricula matricula) => _repository.AddAsync(matricula);
        public Task UpdateAsync(Matricula matricula) => _repository.UpdateAsync(matricula);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

