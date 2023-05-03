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
    public class TbproductoController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbproductoController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbproducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbproducto>>> GetTbproductos()
        {
          if (_context.Tbproductos == null)
          {
              return NotFound();
          }
            return await _context.Tbproductos.ToListAsync();
        }

        // GET: api/Tbproducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbproducto>> GetTbproducto(int id)
        {
          if (_context.Tbproductos == null)
          {
              return NotFound();
          }
            var tbproducto = await _context.Tbproductos.FindAsync(id);

            if (tbproducto == null)
            {
                return NotFound();
            }

            return tbproducto;
        }

        // PUT: api/Tbproducto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbproducto(int id, Tbproducto tbproducto)
        {
            if (id != tbproducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbproducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbproductoExists(id))
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

        // POST: api/Tbproducto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbproducto>> PostTbproducto(Tbproducto tbproducto)
        {
          if (_context.Tbproductos == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbproductos'  is null.");
          }
            _context.Tbproductos.Add(tbproducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbproducto", new { id = tbproducto.Id }, tbproducto);
        }

        // DELETE: api/Tbproducto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbproducto(int id)
        {
            if (_context.Tbproductos == null)
            {
                return NotFound();
            }
            var tbproducto = await _context.Tbproductos.FindAsync(id);
            if (tbproducto == null)
            {
                return NotFound();
            }

            _context.Tbproductos.Remove(tbproducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbproductoExists(int id)
        {
            return (_context.Tbproductos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
