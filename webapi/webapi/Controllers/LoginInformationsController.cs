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
    public class LoginInformationsController : ControllerBase
    {
        private readonly TriangleContext _context;

        public LoginInformationsController(TriangleContext context)
        {
            _context = context;
        }

        // GET: api/LoginInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginInformation>>> GetLoginInformation()
        {
            return await _context.LoginInformation.ToListAsync();
        }

        // GET: api/LoginInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginInformation>> GetLoginInformation(int id)
        {
            var loginInformation = await _context.LoginInformation.FindAsync(id);

            if (loginInformation == null)
            {
                return NotFound();
            }

            return loginInformation;
        }

        // PUT: api/LoginInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginInformation(int id, LoginInformation loginInformation)
        {
            if (id != loginInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(loginInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginInformationExists(id))
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

        // POST: api/LoginInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostLoginInformation([FromBody] LoginInformation loginInformation)
        {
            bool exists = _context.LoginInformation.Any(e => e.Account == loginInformation.Account);
            if (exists == true)
            {
                return "此帳號已註冊";
            }
            else
            { 
                _context.LoginInformation.Add(loginInformation);
                await _context.SaveChangesAsync();

                return "註冊成功";
            }

        }

        // DELETE: api/LoginInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginInformation(int id)
        {
            var loginInformation = await _context.LoginInformation.FindAsync(id);
            if (loginInformation == null)
            {
                return NotFound();
            }

            _context.LoginInformation.Remove(loginInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginInformationExists(int id)
        {
            return _context.LoginInformation.Any(e => e.Id == id);
        }
    }
}
