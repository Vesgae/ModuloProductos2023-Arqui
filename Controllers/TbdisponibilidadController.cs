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
    public class TbdisponibilidadController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbdisponibilidadController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbdisponibilidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbdisponibilidad>>> GetTbdisponibilidads()
        {
          if (_context.Tbdisponibilidads == null)
          {
              return NotFound();
          }
            return await _context.Tbdisponibilidads.ToListAsync();
        }

        // GET: api/Tbdisponibilidad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbdisponibilidad>> GetTbdisponibilidad(int id)
        {
          if (_context.Tbdisponibilidads == null)
          {
              return NotFound();
          }
            var tbdisponibilidad = await _context.Tbdisponibilidads.FindAsync(id);

            if (tbdisponibilidad == null)
            {
                return NotFound();
            }

            return tbdisponibilidad;
        }

        // PUT: api/Tbdisponibilidad/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbdisponibilidad(int id, Tbdisponibilidad tbdisponibilidad)
        {
            if (id != tbdisponibilidad.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbdisponibilidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbdisponibilidadExists(id))
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

        // POST: api/Tbdisponibilidad
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbdisponibilidad>> PostTbdisponibilidad(Tbdisponibilidad tbdisponibilidad)
        {
          if (_context.Tbdisponibilidads == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbdisponibilidads'  is null.");
          }
            _context.Tbdisponibilidads.Add(tbdisponibilidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbdisponibilidad", new { id = tbdisponibilidad.Id }, tbdisponibilidad);
        }

        // DELETE: api/Tbdisponibilidad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbdisponibilidad(int id)
        {
            if (_context.Tbdisponibilidads == null)
            {
                return NotFound();
            }
            var tbdisponibilidad = await _context.Tbdisponibilidads.FindAsync(id);
            if (tbdisponibilidad == null)
            {
                return NotFound();
            }

            _context.Tbdisponibilidads.Remove(tbdisponibilidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbdisponibilidadExists(int id)
        {
            return (_context.Tbdisponibilidads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
