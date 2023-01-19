using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Xml.Linq;
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
    public class CandidatesController : ControllerBase
    {
        private readonly TriangleContext _context;

        public CandidatesController(TriangleContext context)
        {
            _context = context;
        }

        // GET: api/Candidates
        [HttpGet("Id{Id}")]
        public async Task<IEnumerable<CandidateDTO>> GetInterest(int Id)
        {
            return _context.Candidate.Where(c => c.CandidateId == Id).Join(_context.Interest, c => c.CandidateId, i => i.CandidateId, (c, i) => new CandidateDTO
            {
                CandidateId = c.CandidateId,
                //會員中心內容(關注、感興趣...)
                EnterpriseId = i.EnterpriseId,
                VacancyId = i.VacancyId,
                interestStatus = i.InterestStatus,

            });
        }

        // GET: api/Candidates/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Candidate>> GetCandidate(int? id)
        {

            return _context.Candidate.Where(c => c.CandidateId == id).Select(c => new Candidate
            {
                CandidateId = c.CandidateId,
                Account = c.Account,
                Password = c.Password,
                Name = c.Name,
                Email = c.Email,
                Cellphone = c.Cellphone,
                Birth = c.Birth,
                Address = c.Address,
                Education = c.Education,
                Schoolname = c.Schoolname,
                Seniority = c.Seniority,
                Status = c.Status,
                Img = c.Img,
                Autobiography = c.Autobiography,
                Workexname = c.Workexname,
                Workexperience = c.Workexperience,
                
            });

        }

        // PUT: api/Candidates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<String> PutCandidate(int id, Candidate candidate)
        {
            //if (id != candidate.CandidateId)
            //{
            //    return "ID不正確!";
            //}
            Candidate c =  await _context.Candidate.FindAsync(candidate.CandidateId);
            c.Name = candidate.Name;
            c.Email = candidate.Email;
            c.Cellphone = candidate.Cellphone;
            c.Birth = candidate.Birth;
            c.Status =candidate.Status;
            c.Workexname = candidate.Workexname;
            c.Schoolname = candidate.Schoolname;
            c.Education = candidate.Education;
            c.Autobiography = candidate.Autobiography;
            c.Workexperience = candidate.Workexperience;
            _context.Entry(c).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
                {
                    return "找不到欲修改的記錄!";
                }
                else
                {
                    throw;
                }
            }

            return "修改成功!";
        }

        // POST: api/Candidates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostCandidate([FromBody] Candidate candidate)
        {
            bool exists = _context.Candidate.Any(e => e.Account == candidate.Account);
            if (exists == true)
            {
                return "此帳號已註冊";
            }
            else
            {
                _context.Candidate.Add(candidate);
                await _context.SaveChangesAsync();

                return "註冊成功";
            }
        }

        [HttpPost("Login")]
        public async Task<IEnumerable<CandidateDTO>> LoginCandidate([FromBody] CandidateDTO candidate)
        {

            return _context.Candidate.Where(login => login.Account.Contains(candidate.Account) && login.Password == candidate.Password).Select(login => new CandidateDTO
            {
                CandidateId = login.CandidateId,
                Name = login.Name,
                Account = login.Account,
                Password = login.Password,

            });

        }




        // DELETE: api/Candidates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var candidate = await _context.Candidate.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Candidate.Remove(candidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidate.Any(e => e.CandidateId == id);
        }
    }
}
