using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    [EnableCors("AllowAny")]
    [Route("api/[controller]")]
    [ApiController]
    public class AptitudeTestsController : ControllerBase
    {
        private readonly TriangleContext _context;

        public AptitudeTestsController(TriangleContext context)
        {
            _context = context;
        }

        // GET: api/AptitudeTests
        [HttpGet]
        public async Task<IEnumerable<AptitudeTest>> GetAptitudeTest()
        {
            var result = _context.AptitudeTest.Select(x => new AptitudeTest
            {
                QuestionId = x.QuestionId,
                Question = x.Question,
            });
            return result;
        }

        // GET: api/AptitudeTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AptitudeTest>> GetAptitudeTest(int id)
        {
            var aptitudeTest = await _context.AptitudeTest.FindAsync(id);

            if (aptitudeTest == null)
            {
                return NotFound();
            }

            return aptitudeTest;
        }

        // PUT: api/AptitudeTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAptitudeTest(int id, AptitudeTest aptitudeTest)
        {
            if (id != aptitudeTest.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(aptitudeTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AptitudeTestExists(id))
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

        // POST: api/AptitudeTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AptitudeTest>> PostAptitudeTest(AptitudeTest aptitudeTest)
        {
            _context.AptitudeTest.Add(aptitudeTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAptitudeTest", new { id = aptitudeTest.QuestionId }, aptitudeTest);
        }

        // DELETE: api/AptitudeTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAptitudeTest(int id)
        {
            var aptitudeTest = await _context.AptitudeTest.FindAsync(id);
            if (aptitudeTest == null)
            {
                return NotFound();
            }

            _context.AptitudeTest.Remove(aptitudeTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AptitudeTestExists(int id)
        {
            return _context.AptitudeTest.Any(e => e.QuestionId == id);
        }
    }
}
