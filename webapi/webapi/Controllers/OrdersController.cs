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
    public class OrdersController : ControllerBase
    {
        private readonly TriangleContext _context;

        public OrdersController(TriangleContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IEnumerable<OrderDetailDTO>> GetCourseOrder()
        {
            return _context.CourseOrder.Join(_context.Course,a=>a.CourseId,b=>b.CourseId,(co,c)=>new OrderDetailDTO
            {
                OrderId = co.OrderId,
                CandidateId = co.CandidateId,
                CourseId = co.CourseId,
                CourseName = c.CourseName,
                Price = c.Price,
                Buyingtime = co.Buyingtime,
            });
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderDetailDTO>> GetCourseOrder(int? CandidateId,int? CourseId)
        {
            var result = _context.CourseOrder.Where(x => x.CandidateId == CandidateId).Join(_context.Course, a => a.CourseId, b => b.CourseId, (co, c) => new OrderDetailDTO
            {
                OrderId = co.OrderId,
                CandidateId = co.CandidateId,
                CourseId = co.CourseId,
                CourseName = c.CourseName,
                Price = c.Price,
                Buyingtime = co.Buyingtime,
            });
            if (CandidateId is int)
            {
                result = result.Where(x => x.CandidateId == CandidateId);
            }
            if (CourseId is int)
            {
                result = result.Where(x => x.CourseId == CourseId);
            }
            return result;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseOrder(int id, CourseOrder courseOrder)
        {
            if (id != courseOrder.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(courseOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseOrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<CourseOrder> PostCourseOrder(CourseOrder courseOrder)
        {
            CourseOrder co = new CourseOrder
            {
                CandidateId = courseOrder.CandidateId,
                CourseId = courseOrder.CourseId,
                Buyingtime = DateTime.Now,
                Vaild = false,
            };
            _context.CourseOrder.Add(co);
            await _context.SaveChangesAsync();

            return co;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseOrder(int id)
        {
            var courseOrder = await _context.CourseOrder.FindAsync(id);
            if (courseOrder == null)
            {
                return NotFound();
            }

            _context.CourseOrder.Remove(courseOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseOrderExists(int id)
        {
            return _context.CourseOrder.Any(e => e.OrderId == id);
        }
    }
}
