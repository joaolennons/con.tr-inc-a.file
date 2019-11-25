using Api.ViewModels;
using AppServices;
using Microsoft.AspNetCore.Mvc;
using Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("trinca/api/v1/Barbecue")]
    [ApiController]
    public class BarbecueController : ControllerBase
    {
        private readonly IBarbecueAppService _appService;
        private readonly IBarbecueReadonlyRepository _read;
        public BarbecueController(IBarbecueAppService appService, IBarbecueReadonlyRepository read)
        {
            _read = read;
            _appService = appService;
        }

        [HttpPost]
        public async Task<ActionResult<Barbecue>> Post([FromBody] Barbecue bbq)
        {
            try
            {
                bbq.Id = await _appService.CreateBarbecue(bbq);

                return Ok(bbq);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Barbecue>> Put(Guid id, [FromBody] Barbecue bbq)
        {
            try
            {
                bbq.Id = id;
                bbq.UpdateDate = await _appService.UpdateBarbecue(bbq);

                return Ok(bbq);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _appService.DeleteBarbecue(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Read.Dtos.BarbecueDto>>> GetAll()
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

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Read.Dtos.BarbecueDto>>> GetBy(Guid id)
        {
            try
            {
                var response = await _read.GetBy(id);

                if (response == null)
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
