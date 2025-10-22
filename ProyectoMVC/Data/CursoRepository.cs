using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data
{
    public class CursoRepository : ICursoRepository
    {
        private readonly string _connectionString;
        public CursoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            // Asumimos que el SP devuelve columnas con nombres compatibles:
            // IdCurso, IdGrado, NombreCurso, HorasSemanales, DocenteEncargado, Estado,
            // NombreGrado, NombreDocente (estos últimos opcionales)
            return await conn.QueryAsync<Curso>(
                "sp_Curso_GetAll",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Curso> GetByIdAsync(int idCurso)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            return await conn.QueryFirstOrDefaultAsync<Curso>(
                "sp_Curso_GetById",
                new { IdCurso = idCurso },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AddAsync(Curso curso)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Curso_Insert",
                new
                {
                    curso.IdGrado,
                    curso.NombreCurso,
                    curso.HorasSemanales,
                    curso.DocenteEncargado,
                    curso.Estado
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateAsync(Curso curso)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Curso_Update",
                new
                {
                    curso.IdCurso,
                    curso.IdGrado,
                    curso.NombreCurso,
                    curso.HorasSemanales,
                    curso.DocenteEncargado,
                    curso.Estado
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteAsync(int idCurso)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Curso_Delete",
                new { IdCurso = idCurso },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
