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
    public class TbvehiculoenventaController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbvehiculoenventaController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbvehiculoenventa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbvehiculoenventum>>> GetTbvehiculoenventa()
        {
          if (_context.Tbvehiculoenventa == null)
          {
              return NotFound();
          }
            return await _context.Tbvehiculoenventa.ToListAsync();
        }

        // GET: api/Tbvehiculoenventa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbvehiculoenventum>> GetTbvehiculoenventum(int id)
        {
          if (_context.Tbvehiculoenventa == null)
          {
              return NotFound();
          }
            var tbvehiculoenventum = await _context.Tbvehiculoenventa.FindAsync(id);

            if (tbvehiculoenventum == null)
            {
                return NotFound();
            }

            return tbvehiculoenventum;
        }

        // PUT: api/Tbvehiculoenventa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbvehiculoenventum(int id, Tbvehiculoenventum tbvehiculoenventum)
        {
            if (id != tbvehiculoenventum.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbvehiculoenventum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbvehiculoenventumExists(id))
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

        // POST: api/Tbvehiculoenventa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbvehiculoenventum>> PostTbvehiculoenventum(Tbvehiculoenventum tbvehiculoenventum)
        {
          if (_context.Tbvehiculoenventa == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbvehiculoenventa'  is null.");
          }
            _context.Tbvehiculoenventa.Add(tbvehiculoenventum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbvehiculoenventum", new { id = tbvehiculoenventum.Id }, tbvehiculoenventum);
        }

        // DELETE: api/Tbvehiculoenventa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbvehiculoenventum(int id)
        {
            if (_context.Tbvehiculoenventa == null)
            {
                return NotFound();
            }
            var tbvehiculoenventum = await _context.Tbvehiculoenventa.FindAsync(id);
            if (tbvehiculoenventum == null)
            {
                return NotFound();
            }

            _context.Tbvehiculoenventa.Remove(tbvehiculoenventum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbvehiculoenventumExists(int id)
        {
            return (_context.Tbvehiculoenventa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
