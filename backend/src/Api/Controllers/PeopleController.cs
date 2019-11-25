using Microsoft.AspNetCore.Mvc;
using Read.Dtos;
using Read.QueryHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var response = await _read.GetAll();

                if (!response.Any())
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}