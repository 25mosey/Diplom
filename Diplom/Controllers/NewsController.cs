using Diplom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private DiplomContext db;
        public NewsController(DiplomContext ctx)
        {
            db = ctx;
        }

        [HttpPost]
        public void SaveNews([FromBody] News news)
        {
            if (news != null)
            {
                db.News.Add(news);
                db.SaveChanges();
            }
        }
        [HttpPut]
        public async Task<ActionResult<News>> Put(News news)
        {

            if (news == null)
            {
                return BadRequest();
            }
            if (!db.News.Any(x => x.NewsId == news.NewsId))
            {
                return NotFound();
            }
            db.Update(news);
            await db.SaveChangesAsync();
            return Ok(news);

        }
        [HttpGet]
        public IEnumerable<News> GetNews()
        {
            return db.News.ToList();
        }
        [HttpGet("{id}")]
        public IEnumerable<News> GetNews(int id)
        {
            return db.News.Where(p => p.NewsId == id).ToList();
        }
        [HttpDelete("{id}")]
        public void DeleteNew(long id)
        {
            db.News.Remove(db.News.Where(p => p.NewsId == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
