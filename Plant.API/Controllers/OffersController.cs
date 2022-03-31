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
    public class OffersController : ControllerBase
    {
        private readonly PlantAPIContext db;
        private readonly IMapper mapper;

        public OffersController(PlantAPIContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // GET: api/Offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferDto>>> GetOffer()
        {
            var offerDto = mapper.Map<IEnumerable<OfferDto>>(await db.Offer.OrderBy(e => e.StartDate).ToListAsync());
            return Ok(offerDto);
        }

        // GET: api/Offers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDto>> GetOffer(int id)
        {
            var offer = mapper.Map<IEnumerable<OfferDto>>(await db.Offer.FirstOrDefaultAsync(e => e.Id == id));

            if (offer == null)
            {
                return NotFound();
            }
            var offerDto = mapper.Map<OfferDto>(offer);

            return offerDto;
        }

        // PUT: api/Offers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffer(int id, Offer offer)
        {
            if (id != offer.Id)
            {
                return BadRequest();
            }

            db.Entry(offer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(id))
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

        // POST: api/Offers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Offer>> PostOffer(Offer offer)
        {
            db.Offer.Add(offer);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetOffer", new { id = offer.Id }, offer);
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var offer = await db.Offer.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            db.Offer.Remove(offer);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool OfferExists(int id)
        {
            return db.Offer.Any(e => e.Id == id);
        }
    }
}
