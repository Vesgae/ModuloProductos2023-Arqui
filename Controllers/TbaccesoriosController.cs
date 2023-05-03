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
    public class TbaccesoriosController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbaccesoriosController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbaccesorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbaccesorio>>> GetTbaccesorios()
        {
          if (_context.Tbaccesorios == null)
          {
              return NotFound();
          }
            return await _context.Tbaccesorios.ToListAsync();
        }

        // GET: api/Tbaccesorios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbaccesorio>> GetTbaccesorio(int id)
        {
          if (_context.Tbaccesorios == null)
          {
              return NotFound();
          }
            var tbaccesorio = await _context.Tbaccesorios.FindAsync(id);

            if (tbaccesorio == null)
            {
                return NotFound();
            }

            return tbaccesorio;
        }

        // PUT: api/Tbaccesorios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbaccesorio(int id, Tbaccesorio tbaccesorio)
        {
            if (id != tbaccesorio.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbaccesorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbaccesorioExists(id))
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

        // POST: api/Tbaccesorios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbaccesorio>> PostTbaccesorio(Tbaccesorio tbaccesorio)
        {
          if (_context.Tbaccesorios == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbaccesorios'  is null.");
          }
            _context.Tbaccesorios.Add(tbaccesorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbaccesorio", new { id = tbaccesorio.Id }, tbaccesorio);
        }

        // DELETE: api/Tbaccesorios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbaccesorio(int id)
        {
            if (_context.Tbaccesorios == null)
            {
                return NotFound();
            }
            var tbaccesorio = await _context.Tbaccesorios.FindAsync(id);
            if (tbaccesorio == null)
            {
                return NotFound();
            }

            _context.Tbaccesorios.Remove(tbaccesorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbaccesorioExists(int id)
        {
            return (_context.Tbaccesorios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
