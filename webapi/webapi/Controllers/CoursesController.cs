using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using webapi.DTO;
using webapi.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace webapi.Controllers
{
    [EnableCors("AllowAny")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly TriangleContext _context;

        public CoursesController(TriangleContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<IEnumerable<CourseDetailDTO>> GetCourse(string? keyword,string?category)
        {
            var result = from c in _context.Course
                         join t in _context.Teacher on c.TeacherId equals t.TeacherId
                         join co in _context.CourseOrder on c.CourseId equals co.CourseId
                         group new { c, t } by new
                         {
                             c.CourseId,
                             c.CourseName,
                             c.Price,
                             t.TeacherId,
                             t.Name,
                             t.Img,
                             t.Intro,
                             c.CourseReqire,
                             c.CourseIntro,
                             c.CourseLength,
                             c.CourseImg,
                             c.Keyword,
                             c.Category
                         } into g
                         select new CourseDetailDTO()
                         {
                             CourseId = g.Key.CourseId,
                             CourseName = g.Key.CourseName,
                             Price = g.Key.Price,
                             TeacherId = g.Key.TeacherId,
                             TeacherName = g.Key.Name,
                             TeacherImg = g.Key.Img,
                             Intro = g.Key.Intro,
                             CourseReqire = g.Key.CourseReqire,
                             CourseIntro = g.Key.CourseIntro,
                             CourseLength = g.Key.CourseLength,
                             CourseImg = g.Key.CourseImg,
                             keyword = g.Key.Keyword,
                             category = g.Key.Category,
                             studentCount = g.Count()
                         };


            if (!string.IsNullOrWhiteSpace(keyword))
            {
                result = result.Where(x=>x.keyword.Contains(keyword));
            }
            if (!string.IsNullOrWhiteSpace(category))
            {
                result = result.Where(x => x.category.Contains(category));
            }
            return result;
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<CourseDetailDTO>> GetCourse(int id)
        {

            var result = from c in _context.Course
                         join t in _context.Teacher on c.TeacherId equals t.TeacherId
                         join co in _context.CourseOrder on c.CourseId equals co.CourseId
                         where c.CourseId == id
                         group new { c, t } by new
                         {
                             c.CourseId,
                             c.CourseName,
                             c.Price,
                             t.TeacherId,
                             t.Name,
                             t.Img,
                             t.Intro,
                             c.CourseReqire,
                             c.CourseIntro,
                             c.CourseLength,
                             c.CourseImg,
                             c.Keyword,
                             c.Category
                         } into g
                         select new CourseDetailDTO()
                         {
                             CourseId = g.Key.CourseId,
                             CourseName = g.Key.CourseName,
                             Price = g.Key.Price,
                             TeacherId = g.Key.TeacherId,
                             TeacherName = g.Key.Name,
                             TeacherImg = g.Key.Img,
                             Intro = g.Key.Intro,
                             CourseReqire = g.Key.CourseReqire,
                             CourseIntro = g.Key.CourseIntro,
                             CourseLength = g.Key.CourseLength,
                             CourseImg = g.Key.CourseImg,
                             keyword = g.Key.Keyword,
                             category = g.Key.Category,
                             studentCount = g.Count()
                         };

            return result;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Course.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }
    }
}
