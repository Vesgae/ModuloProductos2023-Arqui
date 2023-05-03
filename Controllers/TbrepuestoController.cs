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
    public class TbrepuestoController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbrepuestoController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbrepuesto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbrepuesto>>> GetTbrepuestos()
        {
          if (_context.Tbrepuestos == null)
          {
              return NotFound();
          }
            return await _context.Tbrepuestos.ToListAsync();
        }

        // GET: api/Tbrepuesto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbrepuesto>> GetTbrepuesto(int id)
        {
          if (_context.Tbrepuestos == null)
          {
              return NotFound();
          }
            var tbrepuesto = await _context.Tbrepuestos.FindAsync(id);

            if (tbrepuesto == null)
            {
                return NotFound();
            }

            return tbrepuesto;
        }

        // PUT: api/Tbrepuesto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbrepuesto(int id, Tbrepuesto tbrepuesto)
        {
            if (id != tbrepuesto.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbrepuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbrepuestoExists(id))
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

        // POST: api/Tbrepuesto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbrepuesto>> PostTbrepuesto(Tbrepuesto tbrepuesto)
        {
          if (_context.Tbrepuestos == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbrepuestos'  is null.");
          }
            _context.Tbrepuestos.Add(tbrepuesto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbrepuesto", new { id = tbrepuesto.Id }, tbrepuesto);
        }

        // DELETE: api/Tbrepuesto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbrepuesto(int id)
        {
            if (_context.Tbrepuestos == null)
            {
                return NotFound();
            }
            var tbrepuesto = await _context.Tbrepuestos.FindAsync(id);
            if (tbrepuesto == null)
            {
                return NotFound();
            }

            _context.Tbrepuestos.Remove(tbrepuesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbrepuestoExists(int id)
        {
            return (_context.Tbrepuestos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
