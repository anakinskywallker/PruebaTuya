using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Logistica.Api.Data;
using Logistica.Api.Models;

namespace Logistica.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly LogisticaApiContext _context;

        public PedidosController(LogisticaApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedido.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedidos(int id)
        {
            var pedidos = await _context.Pedido.FindAsync(id);

            if (pedidos == null)
            {
                return NotFound();
            }

            return pedidos;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidos(int id, Pedido pedidos)
        {
            if (id != pedidos.idPedido)
            {
                return BadRequest();
            }

            _context.Entry(pedidos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidosExists(id))
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
        public async Task<ActionResult<Pedido>> PostPedidos(Pedido pedidos)
        {
            _context.Pedido.Add(pedidos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidos", new { id = pedidos.idPedido }, pedidos);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidos(int id)
        {
            var pedidos = await _context.Pedido.FindAsync(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedidos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidosExists(int id)
        {
            return _context.Pedido.Any(e => e.idPedido == id);
        }
    }
}
