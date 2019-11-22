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
                await _dispatcher.Send(
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
    }
}
