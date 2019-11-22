using Dapper;
using Microsoft.Extensions.Configuration;
using Read.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Read
{
    internal class BarbecueReadonlyRepository : IBarbecueReadonlyRepository
    {
        private readonly IConfiguration _configuration;
        private string _connectionString => _configuration.GetConnectionString(Consts.READ_DB);
        public BarbecueReadonlyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<BarbecueDto>> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
                return await conexao.QueryAsync<BarbecueDto>($"{Queries.Barbecues.GetAll} {Queries.Barbecues.OrderDesc("Date")}");
        }
    }
}
