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
    public class TbmodeloController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbmodeloController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbmodelo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbmodelo>>> GetTbmodelos()
        {
          if (_context.Tbmodelos == null)
          {
              return NotFound();
          }
            return await _context.Tbmodelos.ToListAsync();
        }

        // GET: api/Tbmodelo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbmodelo>> GetTbmodelo(int id)
        {
          if (_context.Tbmodelos == null)
          {
              return NotFound();
          }
            var tbmodelo = await _context.Tbmodelos.FindAsync(id);

            if (tbmodelo == null)
            {
                return NotFound();
            }

            return tbmodelo;
        }

        // PUT: api/Tbmodelo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbmodelo(int id, Tbmodelo tbmodelo)
        {
            if (id != tbmodelo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbmodelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbmodeloExists(id))
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

        // POST: api/Tbmodelo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbmodelo>> PostTbmodelo(Tbmodelo tbmodelo)
        {
          if (_context.Tbmodelos == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbmodelos'  is null.");
          }
            _context.Tbmodelos.Add(tbmodelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbmodelo", new { id = tbmodelo.Id }, tbmodelo);
        }

        // DELETE: api/Tbmodelo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbmodelo(int id)
        {
            if (_context.Tbmodelos == null)
            {
                return NotFound();
            }
            var tbmodelo = await _context.Tbmodelos.FindAsync(id);
            if (tbmodelo == null)
            {
                return NotFound();
            }

            _context.Tbmodelos.Remove(tbmodelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbmodeloExists(int id)
        {
            return (_context.Tbmodelos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
