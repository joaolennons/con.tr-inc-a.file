using Api.ViewModels;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Read;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("trinca/api/v1/Barbecue")]
    [ApiController]
    public class BarbecueController : ControllerBase
    {
        private readonly IMediator _dispatcher;
        private readonly IBarbecueReadonlyRepository _read;
        public BarbecueController(IMediator dispatcher, IBarbecueReadonlyRepository read)
        {
            _read = read;
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<ActionResult<Barbecue>> Post([FromBody] Barbecue bbq)
        {
            try
            {
                bbq.Id = await _dispatcher.Send(
                    EventOrganizer
                        .ScheduleNewBarbecue
                        .Named(bbq.Description)
                        .At(bbq.Date)
                        .WithObservation(bbq.Observation)
                        .Please());

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
                bbq.UpdateDate = await _dispatcher.Send(
                    EventOrganizer
                        .UpdateBarbecue(bbq.Id)
                        .Named(bbq.Description)
                        .At(bbq.Date)
                        .WithObservation(bbq.Observation)
                        .Please());

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
                await _dispatcher.Send(
                    EventOrganizer
                    .CancelBarbecue(id)
                    .Please());

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
                return Ok(await _read.GetAll());
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
                return Ok(await _read.GetBy(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
