using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Facturas.Api.Data;
using Facturas.Api.Models;


namespace Facturas.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly FacturasApiContext _context;

        public FacturasController(FacturasApiContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Facturas>>> GetFacturas()
        {
            return await _context.Facturas.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Facturas>> GetFacturas(int id)
        {
            var facturas = await _context.Facturas.FindAsync(id);

            if (facturas == null)
            {
                return NotFound();
            }

            return facturas;
        }

       
        public async Task<IActionResult> PutFacturas(int id, Models.Facturas facturas)
        {
            if (id != facturas.IdFactura)
            {
                return BadRequest();
            }

            _context.Entry(facturas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturasExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Models.Facturas>> PostFacturas(Facturas.Api.Models.Facturas facturas)
        {
            _context.Facturas.Add(facturas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturas", new { id = facturas.IdFactura }, facturas);
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturas(int id)
        {
            var facturas = await _context.Facturas.FindAsync(id);
            if (facturas == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(facturas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturasExists(int id)
        {
            return _context.Facturas.Any(e => e.IdFactura == id);
        }
    }
}
