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
    public class TbvehiculoController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbvehiculoController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbvehiculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbvehiculo>>> GetTbvehiculos()
        {
          if (_context.Tbvehiculos == null)
          {
              return NotFound();
          }
            return await _context.Tbvehiculos.ToListAsync();
        }

        // GET: api/Tbvehiculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbvehiculo>> GetTbvehiculo(int id)
        {
          if (_context.Tbvehiculos == null)
          {
              return NotFound();
          }
            var tbvehiculo = await _context.Tbvehiculos.FindAsync(id);

            if (tbvehiculo == null)
            {
                return NotFound();
            }

            return tbvehiculo;
        }

        // PUT: api/Tbvehiculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbvehiculo(int id, Tbvehiculo tbvehiculo)
        {
            if (id != tbvehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbvehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbvehiculoExists(id))
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

        // POST: api/Tbvehiculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbvehiculo>> PostTbvehiculo(Tbvehiculo tbvehiculo)
        {
          if (_context.Tbvehiculos == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbvehiculos'  is null.");
          }
            _context.Tbvehiculos.Add(tbvehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbvehiculo", new { id = tbvehiculo.Id }, tbvehiculo);
        }

        // DELETE: api/Tbvehiculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbvehiculo(int id)
        {
            if (_context.Tbvehiculos == null)
            {
                return NotFound();
            }
            var tbvehiculo = await _context.Tbvehiculos.FindAsync(id);
            if (tbvehiculo == null)
            {
                return NotFound();
            }

            _context.Tbvehiculos.Remove(tbvehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbvehiculoExists(int id)
        {
            return (_context.Tbvehiculos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
