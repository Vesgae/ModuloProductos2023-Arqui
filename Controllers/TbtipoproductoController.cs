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
    public class TbtipoproductoController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbtipoproductoController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbtipoproducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbtipoproducto>>> GetTbtipoproductos()
        {
          if (_context.Tbtipoproductos == null)
          {
              return NotFound();
          }
            return await _context.Tbtipoproductos.ToListAsync();
        }

        // GET: api/Tbtipoproducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbtipoproducto>> GetTbtipoproducto(int id)
        {
          if (_context.Tbtipoproductos == null)
          {
              return NotFound();
          }
            var tbtipoproducto = await _context.Tbtipoproductos.FindAsync(id);

            if (tbtipoproducto == null)
            {
                return NotFound();
            }

            return tbtipoproducto;
        }

        // PUT: api/Tbtipoproducto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbtipoproducto(int id, Tbtipoproducto tbtipoproducto)
        {
            if (id != tbtipoproducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbtipoproducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbtipoproductoExists(id))
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

        // POST: api/Tbtipoproducto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbtipoproducto>> PostTbtipoproducto(Tbtipoproducto tbtipoproducto)
        {
          if (_context.Tbtipoproductos == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbtipoproductos'  is null.");
          }
            _context.Tbtipoproductos.Add(tbtipoproducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbtipoproducto", new { id = tbtipoproducto.Id }, tbtipoproducto);
        }

        // DELETE: api/Tbtipoproducto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbtipoproducto(int id)
        {
            if (_context.Tbtipoproductos == null)
            {
                return NotFound();
            }
            var tbtipoproducto = await _context.Tbtipoproductos.FindAsync(id);
            if (tbtipoproducto == null)
            {
                return NotFound();
            }

            _context.Tbtipoproductos.Remove(tbtipoproducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbtipoproductoExists(int id)
        {
            return (_context.Tbtipoproductos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
