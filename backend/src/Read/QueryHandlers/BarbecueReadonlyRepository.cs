using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using Read.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Read
{
    internal class BarbecueReadonlyRepository : IBarbecueReadonlyRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private string _connectionString => _configuration.GetConnectionString(Consts.READ_DB);
        public BarbecueReadonlyRepository(IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<BarbecueDto>> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
                return await conexao.QueryAsync<BarbecueDto>($"{Queries.Barbecues.GetAll} {Queries.Barbecues.OrderDesc("Date")}");
        }

        public async Task<BarbecueInfo> GetBy(Guid id)
        {
            IEnumerable<BarbecueDetail> result;
            using (SqlConnection conexao = new SqlConnection(_connectionString))
                result = await conexao.QueryAsync<BarbecueDetail>(Queries.Barbecues.GetBy(id));

            if (!result.Any())
                return null;

            var participants = result.Where(o => o.ParticipantId != Guid.Empty)
                .Select(projection => new BarbecueInfo.Participant(projection.ParticipantId, projection.Name, projection.Value, projection.Paid));

            return _mapper.Map<BarbecueInfo>(result.First()).AddParticipants(participants);
        }
    }
}
