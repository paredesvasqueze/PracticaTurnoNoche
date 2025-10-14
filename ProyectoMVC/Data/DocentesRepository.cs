using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data
{
    public class DocentesRepository : IDocentesRepository
    {
        private readonly string _connectionString;

        public DocentesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Docentes>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<Docentes>(
                "sp_Docentes_GetAll",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Docentes> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<Docentes>(
                "sp_Docentes_GetById",
                new { IdDocente = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AddAsync(Docentes docente)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Docentes_Insert",
                new
                {
                    docente.IdColegio,
                    docente.Nombres,
                    docente.Apellidos,
                    docente.DNI,
                    docente.Email,
                    docente.Telefono,
                    docente.Especialidad,
                    docente.FechaIngreso,
                    docente.Estado
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateAsync(Docentes docente)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Docentes_Update",
                new
                {
                    docente.IdDocente,
                    docente.IdColegio,
                    docente.Nombres,
                    docente.Apellidos,
                    docente.DNI,
                    docente.Email,
                    docente.Telefono,
                    docente.Especialidad,
                    docente.FechaIngreso,
                    docente.Estado
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Docentes_Delete",
                new { IdDocente = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
