using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMatriculaRepository
{
    Task<IEnumerable<Matricula>> GetAllAsync();
    Task<Matricula> GetByIdAsync(int id);
    Task AddAsync(Matricula matricula);
    Task UpdateAsync(Matricula matricula);
    Task DeleteAsync(int id);
}