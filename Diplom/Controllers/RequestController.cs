using Diplom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private DiplomContext db;
        public RequestController(DiplomContext ctx)
        {
            db = ctx;
        }

        [HttpPost]
        public void SaveRequest([FromBody] Request request)
        {
            if (request != null)
            {
                db.Requests.Add(request);
                db.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Request> GetRequests()
        {
            return db.Requests.ToList();
        }
        [HttpGet("{id}")]
        public IEnumerable<Request> GetRequests(int id)
        {
            return db.Requests.Where(p => p.UserId == id).ToList();
        }
        [HttpPut]
        public async Task<ActionResult<Request>> Put(Request requests)
        {

            if (requests == null)
            {
                return BadRequest();
            }
            if (!db.Requests.Any(x => x.RequestId == requests.RequestId))
            {
                return NotFound();
            }
            db.Update(requests);
            await db.SaveChangesAsync();
            return Ok(requests);

        }
        [HttpDelete("{id}")]
        public void DeleteRequest(long id)
        {
            db.Requests.Remove(db.Requests.Where(p => p.RequestId == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
