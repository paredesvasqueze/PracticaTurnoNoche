using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAlumnoService
    {
        Task<IEnumerable<Alumno>> GetAllAsync();
        Task<Alumno?> GetByIdAsync(int id);
        Task AddAsync(Alumno alumno);
        Task UpdateAsync(Alumno alumno);
        Task DeleteAsync(int id);
    }
}