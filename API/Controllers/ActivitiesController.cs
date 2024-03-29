﻿using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {


        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
        {
            return await Mediator.Send(new AList.Query(), ct);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new ADetails.Query { Id = id });
        }

        [HttpPost]

        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new ACreate.Command {  Activity = activity }));
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditActivity(Guid id,   Activity activity)
        {
            activity.Id = id;

            return Ok(await Mediator.Send(new AEdit.Command { Activity = activity }));
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            
            return Ok(await Mediator.Send(new ADelete.Command { Id = id }));
        }
    }
}
