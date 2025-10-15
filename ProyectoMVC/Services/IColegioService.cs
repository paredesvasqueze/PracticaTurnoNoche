using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IColegioService
    {
        Task<IEnumerable<Colegio>> GetAllAsync();
        Task<Colegio> GetByIdAsync(int id);
        Task AddAsync(Colegio colegio);
        Task UpdateAsync(Colegio colegio);
        Task DeleteAsync(int id);
    }
}
