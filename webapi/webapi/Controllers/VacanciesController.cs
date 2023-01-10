using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using static System.Net.WebRequestMethods;

namespace webapi.Controllers
{
    [EnableCors("AllowAny")] 
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        private readonly TriangleContext _context;

        public VacanciesController(TriangleContext context)
        {
            _context = context;
        }

        // GET: api/Vacancies
        [HttpGet]
        public async Task<IEnumerable<VacancyDTO>> Get(string? name, string? category, string? adress)
        {
            var result = _context.Vacancy.Join(_context.Enterprise, x => x.EnterpriseId, y => y.EnterpriseId, (van, etp) => new VacancyDTO
            {
                WorkName = van.WorkName,
                WorkPlace = van.WorkPlace,
                Salary = van.Salary,
                FullPartTime = van.FullPartTime,
                Shift = van.Shift,
                WorkContent = van.WorkContent,
                updatetime = van.Updatetime,
                Seniority = van.Seniority,
                Category = van.Category,
                CompanyName = etp.CompanyName,
                Address = etp.Address,
                Info = etp.Info,
                img = etp.Img,
                UniformNumbers = etp.UniformNumbers

            });
            if (!string.IsNullOrWhiteSpace(name))
            {
                result = result.Where(a => a.WorkName.Contains(name) || a.CompanyName.Contains(name));
            }
            if (!string.IsNullOrWhiteSpace(category)) 
            {
                result = result.Where(a => a.Category.Contains(category));
            }
            if (!string.IsNullOrWhiteSpace(adress)) 
            {
                result = result.Where(a => a.Address.Contains(adress));
            }

            return await Task.FromResult(result);

            /*var result = from van in _context.Vacancy
                         join etp in _context.Enterprise
                         on van.EnterpriseId equals etp.EnterpriseId
                         select new VacancyDTO {
                             WorkName = van.WorkName,
                             WorkPlace = van.WorkPlace,
                             Salary = van.Salary,
                             FullPartTime = van.FullPartTime,
                             Shift = van.Shift,
                             WorkContent = van.WorkContent,
                             Seniority = van.Seniority,
                         };*/
            /*return _context.Vacancy.Select(x => new VacancyDTO
            {
                
            });*/
        } //完成

        // GET: api/Vacancies/5
        //[HttpGet("{name}")]
        //public async Task<IEnumerable<VacancyDTO>> Getsearch(string name)
        //{
        //    var result = _context.Vacancy.Join(_context.Enterprise, x => x.VacancyId, y => y.EnterpriseId, (van, etp) => new VacancyDTO
        //    {
        //        WorkName = van.WorkName,
        //        WorkPlace = van.WorkPlace,
        //        Salary = van.Salary,
        //        FullPartTime = van.FullPartTime,
        //        Shift = van.Shift,
        //        WorkContent = van.WorkContent,
        //        updatetime = van.Updatetime,
        //        Seniority = van.Seniority,
        //        Category = van.Category,
        //        CompanyName = etp.CompanyName,
        //        Address = etp.Address,
        //        Info = etp.Info,
        //        img = etp.Img,
        //        UniformNumbers = etp.UniformNumbers

        //    });
        //    if (!string.IsNullOrWhiteSpace(name)) 
        //    {
        //        result = result.Where(a => a.WorkName.Contains(name) || a.CompanyName.Contains(name));
        //    }
        //    return result;
        //} //完成

        // PUT: api/Vacancies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacancy(int id, Vacancy vacancy)
        {
            if (id != vacancy.VacancyId)
            {
                return BadRequest();
            }

            _context.Entry(vacancy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacancyExists(id))
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

        // POST: api/Vacancies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vacancy>> PostVacancy(Vacancy vacancy)
        {
            _context.Vacancy.Add(vacancy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacancy", new { id = vacancy.VacancyId }, vacancy);
        }

        // DELETE: api/Vacancies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            var vacancy = await _context.Vacancy.FindAsync(id);
            if (vacancy == null)
            {
                return NotFound();
            }

            _context.Vacancy.Remove(vacancy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacancyExists(int id)
        {
            return _context.Vacancy.Any(e => e.VacancyId == id);
        }
    }
}
