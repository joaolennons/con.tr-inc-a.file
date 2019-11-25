using Api.ViewModels;
using AppServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("trinca/api/v1/Barbecue/{id}/participants")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantAppService _appService;
        public ParticipantController(IParticipantAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public async Task<ActionResult<Presence>> Post(Guid id, [FromBody] Presence presence)
        {
            try
            {
                await _appService.ConfirmPresence(id, presence);

                return Ok(presence);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{participantId}")]
        public async Task<ActionResult<Presence>> Put(Guid id, Guid participantId, [FromBody] Presence presence)
        {
            try
            {
                presence.ParticipantId = participantId;
                await _appService.UpdatePresence(id, presence);

                return Ok(presence);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{participantId}/payment")]
        public async Task<ActionResult<Presence>> UpdatePayment(Guid id, Guid participantId, [FromBody] Payment payment)
        {
            try
            {
                await _appService.UpdatePayment(id, participantId, payment);

                return Ok(payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{participantId}")]
        public async Task<ActionResult<Presence>> Cancel(Guid id, Guid participantId, bool wasPaid)
        {
            try
            {
                await _appService.CancelPresence(id, participantId, wasPaid);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
