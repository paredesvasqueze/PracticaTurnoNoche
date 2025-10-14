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
    public class ColegioRepository : IColegioRepository
    {
        private readonly string _connectionString;

        public ColegioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Colegio>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<Colegio>(
                "sp_Colegio_GetAll",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Colegio> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<Colegio>(
                "sp_Colegio_GetById",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AddAsync(Colegio colegio)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Colegio_Insert",
                new
                {
                    colegio.Nombre,
                    colegio.RUC,
                    colegio.Direccion,
                    colegio.Telefono,
                    colegio.Email,
                    colegio.Director,
                    colegio.Estado
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateAsync(Colegio colegio)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Colegio_Update",
                new
                {
                    colegio.IdColegio,
                    colegio.Nombre,
                    colegio.RUC,
                    colegio.Direccion,
                    colegio.Telefono,
                    colegio.Email,
                    colegio.Director,
                    colegio.Estado
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Colegio_Delete",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
