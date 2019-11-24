using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using Read.Dtos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Read.QueryHandlers
{
    internal class ParticipantReadonlyRepository : IParticipantReadonlyRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private string _connectionString => _configuration.GetConnectionString(Consts.READ_DB);
        public ParticipantReadonlyRepository(IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Participant>> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
                return await conexao.QueryAsync<Participant>($"{Queries.Participants.GetAll}");
        }

    }
}
