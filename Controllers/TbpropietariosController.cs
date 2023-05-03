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
    public class TbpropietariosController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbpropietariosController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbpropietarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbpropietario>>> GetTbpropietarios()
        {
          if (_context.Tbpropietarios == null)
          {
              return NotFound();
          }
            return await _context.Tbpropietarios.ToListAsync();
        }

        // GET: api/Tbpropietarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbpropietario>> GetTbpropietario(int id)
        {
          if (_context.Tbpropietarios == null)
          {
              return NotFound();
          }
            var tbpropietario = await _context.Tbpropietarios.FindAsync(id);

            if (tbpropietario == null)
            {
                return NotFound();
            }

            return tbpropietario;
        }

        // PUT: api/Tbpropietarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbpropietario(int id, Tbpropietario tbpropietario)
        {
            if (id != tbpropietario.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbpropietario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbpropietarioExists(id))
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

        // POST: api/Tbpropietarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbpropietario>> PostTbpropietario(Tbpropietario tbpropietario)
        {
          if (_context.Tbpropietarios == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbpropietarios'  is null.");
          }
            _context.Tbpropietarios.Add(tbpropietario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbpropietario", new { id = tbpropietario.Id }, tbpropietario);
        }

        // DELETE: api/Tbpropietarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbpropietario(int id)
        {
            if (_context.Tbpropietarios == null)
            {
                return NotFound();
            }
            var tbpropietario = await _context.Tbpropietarios.FindAsync(id);
            if (tbpropietario == null)
            {
                return NotFound();
            }

            _context.Tbpropietarios.Remove(tbpropietario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbpropietarioExists(int id)
        {
            return (_context.Tbpropietarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
