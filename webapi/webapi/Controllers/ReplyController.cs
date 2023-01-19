using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly TriangleContext _context;

        public ReplyController(TriangleContext context)
        {
            _context = context;
        }

        // GET: api/Reply
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reply>>> GetReply()
        {
            return await _context.Reply.ToListAsync();
        }

        // GET: api/Reply/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reply>> GetReply(int id)
        {
            var reply = await _context.Reply.FindAsync(id);

            if (reply == null)
            {
                return NotFound();
            }

            return reply;
        }

        // PUT: api/Reply/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReply(int id, Reply reply)
        {
            if (id != reply.ReplyId)
            {
                return BadRequest();
            }

            _context.Entry(reply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReplyExists(id))
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

        // POST: api/Reply
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reply>> PostReply(Reply reply)
        {
            _context.Reply.Add(reply);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReply", new { id = reply.ReplyId }, reply);
        }

        // DELETE: api/Reply/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReply(int id)
        {
            var reply = await _context.Reply.FindAsync(id);
            if (reply == null)
            {
                return NotFound();
            }

            _context.Reply.Remove(reply);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReplyExists(int id)
        {
            return _context.Reply.Any(e => e.ReplyId == id);
        }
    }
}
