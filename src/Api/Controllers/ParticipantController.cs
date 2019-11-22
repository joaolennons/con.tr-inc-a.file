﻿using Api.ViewModels;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("trinca/api/v1/Barbecue/{id}/participants")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IMediator _dispatcher;
        public ParticipantController(IMediator dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<ActionResult<Presence>> Post(Guid id, [FromBody] Presence presence)
        {
            try
            {
                await _dispatcher.Send(
                    EventOrganizer
                        .ConfirmPresence
                        .Of(presence.ParticipantId)
                        .On(id)
                        .Paying(presence.Drinking ? Drinking.Yes : Drinking.No));

                return Ok(presence);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}