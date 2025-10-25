using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly string _connectionString;
        public MatriculaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<Matricula>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<Matricula>(
                "sp_Matricula_GetAll",
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Matricula> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<Matricula>(
                "sp_Matricula_GetById",
                new { IdMatricula = id },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task AddAsync(Matricula matricula)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Matricula_Insert",
                new { 
                    matricula.IdAlumno, 
                    matricula.IdGrado, 
                    matricula.FechaMatricula,
                    matricula.AñoLectivo,
                    matricula.Estado
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task UpdateAsync(Matricula matricula)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Matricula_Update",
                new {
                    matricula.IdMatricula, 
                    matricula.IdAlumno, 
                    matricula.IdGrado, 
                    matricula.FechaMatricula,
                    matricula.AñoLectivo,
                    matricula.Estado
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Matricula_Delete",
                new { IdMatricula = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}