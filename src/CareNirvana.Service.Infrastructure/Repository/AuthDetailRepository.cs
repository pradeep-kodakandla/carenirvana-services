using CareNirvana.Service.Application.Interfaces;
using CareNirvana.Service.Domain.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareNirvana.Service.Infrastructure.Repository
{
    public class AuthDetailRepository : IAuthDetailRepository
    {
        private readonly string _connectionString;

        public AuthDetailRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public async Task SaveAsync(AuthDetail authDetail)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand(
                    "INSERT INTO authdetail (data, createdon) VALUES (@data, @createdon)", connection))
                {
                    command.Parameters.AddWithValue("@data", authDetail.Data);
                    command.Parameters.AddWithValue("@createdon", authDetail.CreatedOn);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
