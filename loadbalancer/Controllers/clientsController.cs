using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using loadbalancer.models;

namespace loadbalancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientsController : ControllerBase
    {
        private readonly loadbalancerContext _context;

        public clientsController(loadbalancerContext context)
        {
            _context = context;
        }

        // GET: api/clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientItems()
        {
            return await _context.ClientItems.ToListAsync();
        }

        // GET: api/clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Getclient(long id)
        {
            var client = await _context.ClientItems.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putclient(long id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientExists(id))
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

        // POST: api/clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> Postclient(Client client)
        {
            _context.ClientItems.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getclient", new { id = client.Id }, client);
        }

        // DELETE: api/clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteclient(long id)
        {
            var client = await _context.ClientItems.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.ClientItems.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clientExists(long id)
        {
            return _context.ClientItems.Any(e => e.Id == id);
        }
    }
}
