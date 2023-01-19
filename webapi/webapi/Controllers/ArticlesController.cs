using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DTO;
using webapi.Models;

namespace webapi.Controllers
{
    [EnableCors("AllowAny")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly TriangleContext _context;

        public ArticlesController(TriangleContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<IEnumerable<ArticleDTO>> GetArticle()
        {
            var result = _context.Article.Join(_context.Teacher, x => x.AuthorId, y => y.TeacherId, (article, teacher) => new ArticleDTO
            {
                Title = article.Title,
                ArticleContent = article.ArticleContent,
                Img = article.Img,
                Update = article.UpdateTime.Value.ToString("yyyy-MM-dd"),
                Author = teacher.Name,
                UpdateTime = article.UpdateTime,
                ArticleId = article.ArticleId,
            });

            return await Task.FromResult(result);


            //       var result = _context.Article.Select(x => new ArticleDTO
            //     {
            //       Title = x.Title,
            //     ArticleContent = x.ArticleContent,
            //   Img = x.img,
            // UpdateTime = x.UpdateTime,
            // Author = x.AuthorId
            //  });
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<ArticleDTO>> GetArticle(int? id)
        {
            var result = _context.Article.Join(_context.Teacher, x => x.AuthorId, y => y.TeacherId, (article, teacher) => new ArticleDTO
            {
                Title = article.Title,
                ArticleContent = article.ArticleContent,
                Img = article.Img,
                Update = article.UpdateTime.Value.ToString("yyyy-MM-dd"),
                Author = teacher.Name,
                UpdateTime = article.UpdateTime,
                ArticleId = article.ArticleId,
                Expreience = teacher.Experience,


            }).Where(x => x.ArticleId == id);

            return result;
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, Article article)
        {
            if (id != article.ArticleId)
            {
                return BadRequest();
            }

            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
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

        // POST: api/Articles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            _context.Article.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticle", new { id = article.ArticleId }, article);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _context.Article.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Article.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.ArticleId == id);
        }
    }
}
