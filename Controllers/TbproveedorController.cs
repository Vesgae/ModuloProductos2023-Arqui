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
    public class TbproveedorController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;

        public TbproveedorController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Tbproveedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbproveedor>>> GetTbproveedors()
        {
          if (_context.Tbproveedors == null)
          {
              return NotFound();
          }
            return await _context.Tbproveedors.ToListAsync();
        }

        // GET: api/Tbproveedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbproveedor>> GetTbproveedor(int id)
        {
          if (_context.Tbproveedors == null)
          {
              return NotFound();
          }
            var tbproveedor = await _context.Tbproveedors.FindAsync(id);

            if (tbproveedor == null)
            {
                return NotFound();
            }

            return tbproveedor;
        }

        // PUT: api/Tbproveedor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbproveedor(int id, Tbproveedor tbproveedor)
        {
            if (id != tbproveedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbproveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbproveedorExists(id))
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

        // POST: api/Tbproveedor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbproveedor>> PostTbproveedor(Tbproveedor tbproveedor)
        {
          if (_context.Tbproveedors == null)
          {
              return Problem("Entity set 'DbserviciosproductosvehiculosContext.Tbproveedors'  is null.");
          }
            _context.Tbproveedors.Add(tbproveedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbproveedor", new { id = tbproveedor.Id }, tbproveedor);
        }

        // DELETE: api/Tbproveedor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbproveedor(int id)
        {
            if (_context.Tbproveedors == null)
            {
                return NotFound();
            }
            var tbproveedor = await _context.Tbproveedors.FindAsync(id);
            if (tbproveedor == null)
            {
                return NotFound();
            }

            _context.Tbproveedors.Remove(tbproveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbproveedorExists(int id)
        {
            return (_context.Tbproveedors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
