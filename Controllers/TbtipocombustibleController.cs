using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuloProductos_v1.Entities;

namespace ModuloProductos_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbtipocombustibleController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbtipocombustibleController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbtipocombustible
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbtipocombustible>>> GetTbtipocombustibles()
        {
          if (_context.Tbtipocombustibles == null)
          {
              return NotFound();
          }
            return await _context.Tbtipocombustibles.ToListAsync();
        }

        // GET: api/Tbtipocombustible/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbtipocombustible>> GetTbtipocombustible(int id)
        {
          if (_context.Tbtipocombustibles == null)
          {
              return NotFound();
          }
            var tbtipocombustible = await _context.Tbtipocombustibles.FindAsync(id);

            if (tbtipocombustible == null)
            {
                return NotFound();
            }

            return tbtipocombustible;
        }

        // PUT: api/Tbtipocombustible/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbtipocombustible(int id, Tbtipocombustible tbtipocombustible)
        {
            if (id != tbtipocombustible.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbtipocombustible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbtipocombustibleExists(id))
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

        // POST: api/Tbtipocombustible
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbtipocombustible>> PostTbtipocombustible(Tbtipocombustible tbtipocombustible)
        {
          if (_context.Tbtipocombustibles == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbtipocombustibles'  is null.");
          }
            _context.Tbtipocombustibles.Add(tbtipocombustible);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbtipocombustible", new { id = tbtipocombustible.Id }, tbtipocombustible);
        }

        // DELETE: api/Tbtipocombustible/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbtipocombustible(int id)
        {
            if (_context.Tbtipocombustibles == null)
            {
                return NotFound();
            }
            var tbtipocombustible = await _context.Tbtipocombustibles.FindAsync(id);
            if (tbtipocombustible == null)
            {
                return NotFound();
            }

            _context.Tbtipocombustibles.Remove(tbtipocombustible);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbtipocombustibleExists(int id)
        {
            return (_context.Tbtipocombustibles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
