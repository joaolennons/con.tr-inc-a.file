using Microsoft.AspNetCore.Mvc;
using Read.Dtos;
using Read.QueryHandlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("trinca/api/v1/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IParticipantReadonlyRepository _read;
        public PeopleController(IParticipantReadonlyRepository read)
        {
            _read = read;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Participant>>> GetAll()
        {
            try
            {
                return Ok(await _read.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}