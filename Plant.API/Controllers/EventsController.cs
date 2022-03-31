#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plant.Data.Data;
using Plant.Core.Enteties;
using AutoMapper;
using Plant.Core.DTOs;

namespace Plant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly PlantAPIContext db;
        private readonly IMapper mapper;

        public EventsController(PlantAPIContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvent()
        {
            var eventDto =  mapper.Map<IEnumerable<EventDto>>(await db.Event.Include(a => a.Address)
                                                                            .Include(e => e.Offers)
                                                                            .OrderBy(e => e.Date)
                                                                            .ToListAsync());
            return Ok(eventDto);
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var @event = await db.Event.Include(e => e.Address).Include(e => e.Offers.OrderBy(e => e.StartDate)).FirstOrDefaultAsync(e => e.Id == id);

            if (@event == null)
            {
                return NotFound();
            }

            var eventDto = mapper.Map<EventDto>(@event);
           
            return eventDto;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            db.Event.Add(@event);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await db.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Event.Remove(@event);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return db.Event.Any(e => e.Id == id);
        }
    }
}
