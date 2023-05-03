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
    public class TbaccesorioenventaController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbaccesorioenventaController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbaccesorioenventa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbaccesorioenventum>>> GetTbaccesorioenventa()
        {
          if (_context.Tbaccesorioenventa == null)
          {
              return NotFound();
          }
            return await _context.Tbaccesorioenventa.ToListAsync();
        }

        // GET: api/Tbaccesorioenventa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbaccesorioenventum>> GetTbaccesorioenventum(int id)
        {
          if (_context.Tbaccesorioenventa == null)
          {
              return NotFound();
          }
            var tbaccesorioenventum = await _context.Tbaccesorioenventa.FindAsync(id);

            if (tbaccesorioenventum == null)
            {
                return NotFound();
            }

            return tbaccesorioenventum;
        }

        // PUT: api/Tbaccesorioenventa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbaccesorioenventum(int id, Tbaccesorioenventum tbaccesorioenventum)
        {
            if (id != tbaccesorioenventum.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbaccesorioenventum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbaccesorioenventumExists(id))
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

        // POST: api/Tbaccesorioenventa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbaccesorioenventum>> PostTbaccesorioenventum(Tbaccesorioenventum tbaccesorioenventum)
        {
          if (_context.Tbaccesorioenventa == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbaccesorioenventa'  is null.");
          }
            _context.Tbaccesorioenventa.Add(tbaccesorioenventum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbaccesorioenventum", new { id = tbaccesorioenventum.Id }, tbaccesorioenventum);
        }

        // DELETE: api/Tbaccesorioenventa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbaccesorioenventum(int id)
        {
            if (_context.Tbaccesorioenventa == null)
            {
                return NotFound();
            }
            var tbaccesorioenventum = await _context.Tbaccesorioenventa.FindAsync(id);
            if (tbaccesorioenventum == null)
            {
                return NotFound();
            }

            _context.Tbaccesorioenventa.Remove(tbaccesorioenventum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbaccesorioenventumExists(int id)
        {
            return (_context.Tbaccesorioenventa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
