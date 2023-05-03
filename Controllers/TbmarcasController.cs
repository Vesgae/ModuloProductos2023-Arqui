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
    public class TbmarcasController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbmarcasController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbmarcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbmarca>>> GetTbmarcas()
        {
          if (_context.Tbmarcas == null)
          {
              return NotFound();
          }
            return await _context.Tbmarcas.ToListAsync();
        }

        // GET: api/Tbmarcas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbmarca>> GetTbmarca(int id)
        {
          if (_context.Tbmarcas == null)
          {
              return NotFound();
          }
            var tbmarca = await _context.Tbmarcas.FindAsync(id);

            if (tbmarca == null)
            {
                return NotFound();
            }

            return tbmarca;
        }

        // PUT: api/Tbmarcas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbmarca(int id, Tbmarca tbmarca)
        {
            if (id != tbmarca.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbmarca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbmarcaExists(id))
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

        // POST: api/Tbmarcas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbmarca>> PostTbmarca(Tbmarca tbmarca)
        {
          if (_context.Tbmarcas == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbmarcas'  is null.");
          }
            _context.Tbmarcas.Add(tbmarca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbmarca", new { id = tbmarca.Id }, tbmarca);
        }

        // DELETE: api/Tbmarcas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbmarca(int id)
        {
            if (_context.Tbmarcas == null)
            {
                return NotFound();
            }
            var tbmarca = await _context.Tbmarcas.FindAsync(id);
            if (tbmarca == null)
            {
                return NotFound();
            }

            _context.Tbmarcas.Remove(tbmarca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbmarcaExists(int id)
        {
            return (_context.Tbmarcas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
