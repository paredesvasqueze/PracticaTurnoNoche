using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class AlumnoServiceDb : IAlumnoService
    {
        private readonly IAlumnoRepository _repository;

        public AlumnoServiceDb(IAlumnoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Alumno>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Alumno?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Alumno alumno) => _repository.AddAsync(alumno);
        public Task UpdateAsync(Alumno alumno) => _repository.UpdateAsync(alumno);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}