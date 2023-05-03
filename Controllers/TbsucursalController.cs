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
    public class TbsucursalController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbsucursalController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbsucursal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbsucursal>>> GetTbsucursals()
        {
          if (_context.Tbsucursals == null)
          {
              return NotFound();
          }
            return await _context.Tbsucursals.ToListAsync();
        }

        // GET: api/Tbsucursal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbsucursal>> GetTbsucursal(int id)
        {
          if (_context.Tbsucursals == null)
          {
              return NotFound();
          }
            var tbsucursal = await _context.Tbsucursals.FindAsync(id);

            if (tbsucursal == null)
            {
                return NotFound();
            }

            return tbsucursal;
        }

        // PUT: api/Tbsucursal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbsucursal(int id, Tbsucursal tbsucursal)
        {
            if (id != tbsucursal.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbsucursal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbsucursalExists(id))
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

        // POST: api/Tbsucursal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbsucursal>> PostTbsucursal(Tbsucursal tbsucursal)
        {
          if (_context.Tbsucursals == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbsucursals'  is null.");
          }
            _context.Tbsucursals.Add(tbsucursal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbsucursal", new { id = tbsucursal.Id }, tbsucursal);
        }

        // DELETE: api/Tbsucursal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbsucursal(int id)
        {
            if (_context.Tbsucursals == null)
            {
                return NotFound();
            }
            var tbsucursal = await _context.Tbsucursals.FindAsync(id);
            if (tbsucursal == null)
            {
                return NotFound();
            }

            _context.Tbsucursals.Remove(tbsucursal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbsucursalExists(int id)
        {
            return (_context.Tbsucursals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
