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
    public class TbtipovehiculoController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbtipovehiculoController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbtipovehiculoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbtipovehiculo>>> GetTbtipovehiculos()
        {
          if (_context.Tbtipovehiculos == null)
          {
              return NotFound();
          }
            return await _context.Tbtipovehiculos.ToListAsync();
        }

        // GET: api/Tbtipovehiculoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbtipovehiculo>> GetTbtipovehiculo(int id)
        {
          if (_context.Tbtipovehiculos == null)
          {
              return NotFound();
          }
            var tbtipovehiculo = await _context.Tbtipovehiculos.FindAsync(id);

            if (tbtipovehiculo == null)
            {
                return NotFound();
            }

            return tbtipovehiculo;
        }

        // PUT: api/Tbtipovehiculoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbtipovehiculo(int id, Tbtipovehiculo tbtipovehiculo)
        {
            if (id != tbtipovehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbtipovehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbtipovehiculoExists(id))
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

        // POST: api/Tbtipovehiculoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbtipovehiculo>> PostTbtipovehiculo(Tbtipovehiculo tbtipovehiculo)
        {
          if (_context.Tbtipovehiculos == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbtipovehiculos'  is null.");
          }
            _context.Tbtipovehiculos.Add(tbtipovehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbtipovehiculo", new { id = tbtipovehiculo.Id }, tbtipovehiculo);
        }

        // DELETE: api/Tbtipovehiculoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbtipovehiculo(int id)
        {
            if (_context.Tbtipovehiculos == null)
            {
                return NotFound();
            }
            var tbtipovehiculo = await _context.Tbtipovehiculos.FindAsync(id);
            if (tbtipovehiculo == null)
            {
                return NotFound();
            }

            _context.Tbtipovehiculos.Remove(tbtipovehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbtipovehiculoExists(int id)
        {
            return (_context.Tbtipovehiculos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
