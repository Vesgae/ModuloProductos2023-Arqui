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
    public class TbrepuestoenventaController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbrepuestoenventaController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbrepuestoenventa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbrepuestoenventum>>> GetTbrepuestoenventa()
        {
          if (_context.Tbrepuestoenventa == null)
          {
              return NotFound();
          }
            return await _context.Tbrepuestoenventa.ToListAsync();
        }

        // GET: api/Tbrepuestoenventa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbrepuestoenventum>> GetTbrepuestoenventum(int id)
        {
          if (_context.Tbrepuestoenventa == null)
          {
              return NotFound();
          }
            var tbrepuestoenventum = await _context.Tbrepuestoenventa.FindAsync(id);

            if (tbrepuestoenventum == null)
            {
                return NotFound();
            }

            return tbrepuestoenventum;
        }

        // PUT: api/Tbrepuestoenventa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbrepuestoenventum(int id, Tbrepuestoenventum tbrepuestoenventum)
        {
            if (id != tbrepuestoenventum.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbrepuestoenventum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbrepuestoenventumExists(id))
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

        // POST: api/Tbrepuestoenventa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbrepuestoenventum>> PostTbrepuestoenventum(Tbrepuestoenventum tbrepuestoenventum)
        {
          if (_context.Tbrepuestoenventa == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbrepuestoenventa'  is null.");
          }
            _context.Tbrepuestoenventa.Add(tbrepuestoenventum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbrepuestoenventum", new { id = tbrepuestoenventum.Id }, tbrepuestoenventum);
        }

        // DELETE: api/Tbrepuestoenventa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbrepuestoenventum(int id)
        {
            if (_context.Tbrepuestoenventa == null)
            {
                return NotFound();
            }
            var tbrepuestoenventum = await _context.Tbrepuestoenventa.FindAsync(id);
            if (tbrepuestoenventum == null)
            {
                return NotFound();
            }

            _context.Tbrepuestoenventa.Remove(tbrepuestoenventum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbrepuestoenventumExists(int id)
        {
            return (_context.Tbrepuestoenventa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
